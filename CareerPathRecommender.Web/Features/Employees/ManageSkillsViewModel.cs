using CareerPathRecommender.Web.Models;
using System.Collections.Generic;

namespace CareerPathRecommender.Web.Features.Employees
{
    public class ManageSkillsViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Skill> AllSkills { get; set; }
        public List<int> SelectedSkillIds { get; set; } = new();
    }
}
