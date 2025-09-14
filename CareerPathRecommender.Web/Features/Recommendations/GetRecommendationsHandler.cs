using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Infrastructure.Services;
using CareerPathRecommender.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPathRecommender.Web.Features.Recommendations
{
    public class GetRecommendationsHandler:IGetRecommendationsHandler
    {
        private readonly AppDbContext _context;
        private readonly OpenAIService _openAIService;

        public GetRecommendationsHandler(AppDbContext context, OpenAIService openAIService)
        {
            _context = context;
            _openAIService = openAIService;
        }

        public async Task<List<RecommendationDto>> GetRecommendationsForEmployee(string employeeId, int targetRoleId)
        {
            // Get employee with skills
            var employee = await _context.Employees
                .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                .Include(e => e.JobRole)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
                return new List<RecommendationDto>();

            // Get target role with required skills
            var targetRole = await _context.JobRoles
                .Include(jr => jr.JobRoleSkills)
                    .ThenInclude(jrs => jrs.Skill)
                .FirstOrDefaultAsync(jr => jr.Id == targetRoleId);

            if (targetRole == null)
                return new List<RecommendationDto>();

            // Calculate skill gaps
            var currentSkills = employee.EmployeeSkills.Select(s => s.Skill.Name).ToList();
            var targetSkills = targetRole.JobRoleSkills.Select(s => s.Skill.Name).ToList();
            var missingSkills = targetSkills.Except(currentSkills).ToList();

            // Call OpenAI to generate recommendations based on skill gaps
            var recommendations = await _openAIService.GenerateRecommendationsAsync(
                employee,
                targetRole,
                currentSkills,
                targetSkills,
                missingSkills
            );

            return recommendations;
        }
    }
}
