namespace CareerPathRecommender.Web.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<JobRoleSkill> JobRoleSkills { get; set; }
    }
}
