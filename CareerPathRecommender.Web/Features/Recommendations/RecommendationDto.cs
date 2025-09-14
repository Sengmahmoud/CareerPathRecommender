namespace CareerPathRecommender.Web.Features.Recommendations
{
   public class RecommendationDto
{
    public string Type { get; set; }       // "Course", "Mentor", "Project"
    public string Title { get; set; }      // e.g., "Udemy: Master Microservices"
    public string Reason { get; set; }     // e.g., "Missing Microservices skill"
}

}