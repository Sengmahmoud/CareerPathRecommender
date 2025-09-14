using CareerPathRecommender.Web.Models;
using System.Collections.Generic;

namespace CareerPathRecommender.Web.Features.Recommendations
{
    public class RecommendationViewModel
    {
        public Employee Employee { get; set; }
        public List<JobRole> JobRoles { get; set; }
    }
}
