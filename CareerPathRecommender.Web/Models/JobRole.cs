namespace CareerPathRecommender.Web.Models
{
    public class JobRole
    {
        public int Id { get; set; }
        public string Title { get; set; } // e.g. "Software Engineer", "Data Analyst"

        public ICollection<Employee> Employees { get; set; }
        public ICollection<JobRoleSkill> JobRoleSkills { get; set; }
    }
}
