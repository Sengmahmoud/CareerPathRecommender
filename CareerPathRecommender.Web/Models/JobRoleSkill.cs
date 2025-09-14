using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerPathRecommender.Web.Models
{
    public class JobRoleSkill
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("JobRole")]
        public int JobRoleId { get; set; }
        public JobRole JobRole { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public string Level { get; set; } // Beginner / Intermediate / Advanced
    }
}
