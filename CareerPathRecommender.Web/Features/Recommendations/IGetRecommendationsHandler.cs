namespace CareerPathRecommender.Web.Features.Recommendations
{
    public interface IGetRecommendationsHandler
    {
        Task<List<RecommendationDto>> GetRecommendationsForEmployee(string employeeId, int targetRoleId);
    }
}
