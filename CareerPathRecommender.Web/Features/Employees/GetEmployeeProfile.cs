using CareerPathRecommender.Web.Models;
using CareerPathRecommender.Web.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPathRecommender.Web.Features.Employees
{
    public class GetEmployeeProfile 
    {
        private readonly UserManager<Employee> _userManager;
        private readonly AppDbContext _context;

        public GetEmployeeProfile(UserManager<Employee> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Employee> HandleAsync(System.Security.Claims.ClaimsPrincipal user)
        {
            var employee = await _userManager.GetUserAsync(user);
            if (employee == null)
                return null;

            // Load related data
            employee.JobRole = _context.JobRoles.Find(employee.JobRoleId);
            employee.EmployeeSkills = _context.EmployeeSkills.Include(e => e.Skill)
                .Where(es => es.EmployeeId == employee.Id)
                .ToList();

            return employee;
        }
    }
}