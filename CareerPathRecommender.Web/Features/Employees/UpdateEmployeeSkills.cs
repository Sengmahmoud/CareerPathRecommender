using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPathRecommender.Web.Features.Employees
{
    public class UpdateEmployeeSkills
    {
        private readonly AppDbContext _context;

        public UpdateEmployeeSkills(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(string employeeId, List<int> selectedSkillIds)
        {
            // Remove existing skills
            var existingSkills = _context.EmployeeSkills
                .Where(es => es.EmployeeId == employeeId);
            _context.EmployeeSkills.RemoveRange(existingSkills);

            // Add selected skills
            foreach (var skillId in selectedSkillIds)
            {
                _context.EmployeeSkills.Add(new EmployeeSkill
                {
                    EmployeeId = employeeId,
                    SkillId = skillId,
                    Level = "Beginner"
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}