namespace CareerPathRecommender.Web.Models
{
 public class EmployeeSkill
{
    public string EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }

    // Optional: Skill Level (Beginner, Intermediate, Advanced)
    public string Level { get; set; }
}

}