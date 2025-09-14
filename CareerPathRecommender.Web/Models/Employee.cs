using Microsoft.AspNetCore.Identity;

namespace CareerPathRecommender.Web.Models
{
    public class Employee : IdentityUser
    {
        public string FullName { get; set; }

        // Foreign key to JobRole
        public int JobRoleId { get; set; }
        public JobRole JobRole { get; set; }

        // Navigation
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}
