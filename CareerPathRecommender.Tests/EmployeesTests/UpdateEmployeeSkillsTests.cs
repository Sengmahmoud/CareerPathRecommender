using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using CareerPathRecommender.Web.Features.Employees;
using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Models;


namespace CareerPathRecommender.Tests.EmployeesTests
{
    public class UpdateEmployeeSkillsTests
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly string _testEmployeeId = "test-employee-1";

        public UpdateEmployeeSkillsTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestEmployeeSkillsDb")
                .Options;
        }

        [Fact]
        public async Task UpdateAsync_ShouldRemoveExistingSkillsAndAddNewOnes()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                // Clear database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Add initial skills
                var initialSkills = new List<EmployeeSkill>
                {
                    new EmployeeSkill { EmployeeId = _testEmployeeId, SkillId = 1, Level = "Advanced" },
                    new EmployeeSkill { EmployeeId = _testEmployeeId, SkillId = 2, Level = "Intermediate" }
                };
                context.EmployeeSkills.AddRange(initialSkills);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new AppDbContext(_options))
            {
                var handler = new UpdateEmployeeSkills(context);
                var newSkillIds = new List<int> { 3, 4 }; // Different skills
                await handler.UpdateAsync(_testEmployeeId, newSkillIds);
            }

            // Assert
            using (var context = new AppDbContext(_options))
            {
                var updatedSkills = await context.EmployeeSkills
                    .Where(es => es.EmployeeId == _testEmployeeId)
                    .ToListAsync();

                Assert.Equal(2, updatedSkills.Count);
                Assert.Contains(updatedSkills, s => s.SkillId == 3);
                Assert.Contains(updatedSkills, s => s.SkillId == 4);
                Assert.DoesNotContain(updatedSkills, s => s.SkillId == 1);
                Assert.DoesNotContain(updatedSkills, s => s.SkillId == 2);
                Assert.All(updatedSkills, s => Assert.Equal("Beginner", s.Level));
            }
        }

        [Fact]
        public async Task UpdateAsync_ShouldHandleEmptySkillsList()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Add initial skills
                var initialSkills = new List<EmployeeSkill>
                {
                    new EmployeeSkill { EmployeeId = _testEmployeeId, SkillId = 1, Level = "Advanced" }
                };
                context.EmployeeSkills.AddRange(initialSkills);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new AppDbContext(_options))
            {
                var handler = new UpdateEmployeeSkills(context);
                await handler.UpdateAsync(_testEmployeeId, new List<int>()); // Empty skills list
            }

            // Assert
            using (var context = new AppDbContext(_options))
            {
                var updatedSkills = await context.EmployeeSkills
                    .Where(es => es.EmployeeId == _testEmployeeId)
                    .ToListAsync();

                Assert.Empty(updatedSkills);
            }
        }

        [Fact]
        public async Task UpdateAsync_ShouldHandleNonExistentEmployee()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // Act
            using (var context = new AppDbContext(_options))
            {
                var handler = new UpdateEmployeeSkills(context);
                var newSkillIds = new List<int> { 1, 2 };
                await handler.UpdateAsync("non-existent-employee", newSkillIds);
            }

            // Assert
            using (var context = new AppDbContext(_options))
            {
                var skillCount = await context.EmployeeSkills.CountAsync();
                Assert.Equal(2, skillCount); // Skills should still be added even for non-existent employee
            }
        }
    }
}