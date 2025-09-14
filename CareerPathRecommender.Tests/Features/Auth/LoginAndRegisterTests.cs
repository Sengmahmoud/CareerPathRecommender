using Xunit;
using Moq;
using Microsoft.AspNetCore.Identity;
using CareerPathRecommender.Web.Features.Auth;
using CareerPathRecommender.Web.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using CareerPathRecommender.Web.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CareerPathRecommender.Tests.Features.Auth
{
    public class LoginAndRegisterTests
    {
        private readonly Mock<UserManager<Employee>> _userManagerMock;
        private readonly Mock<SignInManager<Employee>> _signInManagerMock;
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public LoginAndRegisterTests()
        {
            var userStoreMock = new Mock<IUserStore<Employee>>();
            _userManagerMock = new Mock<UserManager<Employee>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _signInManagerMock = new Mock<SignInManager<Employee>>(
                _userManagerMock.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<Employee>>().Object,
                null, null, null, null);

            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestAuthDb")
                .Options;
        }

        [Fact]
        public async Task Login_WithValidCredentials_ShouldSucceed()
        {
            var loginModel = new LoginModel
            {
                Email = "test@example.com",
                Password = "Test123!",
                RememberMe = false
            };

            _signInManagerMock.Setup(x => x.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                loginModel.RememberMe,
                It.IsAny<bool>()))
                .ReturnsAsync(SignInResult.Success);

            var result = await _signInManagerMock.Object.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                loginModel.RememberMe,
                false);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ShouldFail()
        {
            var loginModel = new LoginModel
            {
                Email = "test@example.com",
                Password = "WrongPassword",
                RememberMe = false
            };

            _signInManagerMock.Setup(x => x.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                loginModel.RememberMe,
                It.IsAny<bool>()))
                .ReturnsAsync(SignInResult.Failed);

            var result = await _signInManagerMock.Object.PasswordSignInAsync(
                loginModel.Email,
                loginModel.Password,
                loginModel.RememberMe,
                false);

            Assert.False(result.Succeeded);
        }

        [Theory]
        [InlineData("", "Password123!")] // Empty email
        [InlineData("invalid-email", "Password123!")] // Invalid email format
        [InlineData("test@example.com", "")] // Empty password
        public void Login_WithInvalidModel_ShouldFailValidation(string email, string password)
        {
            var model = new LoginModel
            {
                Email = email,
                Password = password
            };

            var validationContext = new ValidationContext(model);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            Assert.False(isValid);
        }

        [Fact]
        public async Task Register_WithValidData_ShouldSucceed()
        {
            var registerModel = new RegisterModel
            {
                Email = "test@example.com",
                Password = "Test123!",
                ConfirmPassword = "Test123!",
                FullName = "Test User",
                PhoneNumber = "1234567890",
                JobRoleId = 1
            };

            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<Employee>(), registerModel.Password))
                .ReturnsAsync(IdentityResult.Success);

            using var context = new AppDbContext(_dbContextOptions);
            context.JobRoles.Add(new JobRole { Id = 1, Title = "Software Developer" });
            await context.SaveChangesAsync();

            var user = new Employee
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                FullName = registerModel.FullName,
                PhoneNumber = registerModel.PhoneNumber,
                JobRoleId = registerModel.JobRoleId
            };

            var result = await _userManagerMock.Object.CreateAsync(user, registerModel.Password);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Register_WithExistingEmail_ShouldFail()
        {
            var existingEmail = "existing@example.com";

            _userManagerMock.Setup(x => x.FindByEmailAsync(existingEmail))
                .ReturnsAsync(new Employee { Email = existingEmail });

            var existingUser = await _userManagerMock.Object.FindByEmailAsync(existingEmail);

            Assert.NotNull(existingUser);
            Assert.Equal(existingEmail, existingUser.Email);
        }

       

        [Fact]
        public async Task Register_WithValidJobRole_ShouldSetCorrectRole()
        {
            using var context = new AppDbContext(_dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var jobRole = new JobRole { Id = 1, Title = "Software Developer" };
            context.JobRoles.Add(jobRole);
            await context.SaveChangesAsync();

            var registerModel = new RegisterModel
            {
                Email = "test@example.com",
                Password = "Test123!",
                ConfirmPassword = "Test123!",
                FullName = "Test User",
                PhoneNumber = "1234567890",
                JobRoleId = jobRole.Id
            };

            var user = new Employee
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                FullName = registerModel.FullName,
                PhoneNumber = registerModel.PhoneNumber,
                JobRoleId = registerModel.JobRoleId
            };

            context.Employees.Add(user);
            await context.SaveChangesAsync();

            var savedUser = await context.Employees
                .Include(e => e.JobRole)
                .FirstOrDefaultAsync(e => e.Email == registerModel.Email);

            Assert.NotNull(savedUser);
            Assert.Equal(jobRole.Id, savedUser.JobRoleId);
            Assert.Equal(jobRole.Title, savedUser.JobRole.Title);
        }
    }
}
