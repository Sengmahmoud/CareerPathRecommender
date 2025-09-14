using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using CareerPathRecommender.Web.Infrastructure.Services;
using CareerPathRecommender.Web.Models;
using System.Collections.Generic;
using System.Text.Json;
using CareerPathRecommender.Web.Features.Recommendations;

namespace CareerPathRecommender.Tests.Services
{
    public class OpenAIServiceTests
    {
        private readonly Employee _testEmployee;
        private readonly JobRole _testTargetRole;
        private readonly List<string> _currentSkills;
        private readonly List<string> _targetSkills;
        private readonly List<string> _missingSkills;

        public OpenAIServiceTests()
        {
            _testEmployee = new Employee
            {
                FullName = "John Doe",
                JobRole = new JobRole { Title = "Software Engineer" }
            };

            _testTargetRole = new JobRole { Title = "Senior Software Engineer" };

            _currentSkills = new List<string> { "C#", "SQL" };
            _targetSkills = new List<string> { "C#", "SQL", "Azure", "Design Patterns" };
            _missingSkills = new List<string> { "Azure", "Design Patterns" };
        }

        [Fact]
        public async Task GenerateRecommendationsAsync_ShouldReturnValidRecommendations()
        {
            // Arrange
            var openAIService = new OpenAIService();

            // Act
            var recommendations = await openAIService.GenerateRecommendationsAsync(
                _testEmployee,
                _testTargetRole,
                _currentSkills,
                _targetSkills,
                _missingSkills
            );

            // Assert
            Assert.NotNull(recommendations);
            Assert.NotEmpty(recommendations);
            Assert.All(recommendations, r =>
            {
                Assert.NotNull(r.Type);
                Assert.NotNull(r.Title);
                Assert.NotNull(r.Reason);
       
            });
        }

        [Fact]
        public async Task GenerateRecommendationsAsync_ShouldHandleEmptySkillsLists()
        {
            // Arrange
            var openAIService = new OpenAIService();

            // Act
            var recommendations = await openAIService.GenerateRecommendationsAsync(
                _testEmployee,
                _testTargetRole,
                new List<string>(),
                new List<string>(),
                new List<string>()
            );

            // Assert
            Assert.NotNull(recommendations);
            Assert.NotEmpty(recommendations);
        }

        [Fact]
        public async Task GenerateRecommendationsAsync_ShouldIncludeRelevantSkillsInReason()
        {
            // Arrange
            var openAIService = new OpenAIService();

            // Act
            var recommendations = await openAIService.GenerateRecommendationsAsync(
                _testEmployee,
                _testTargetRole,
                _currentSkills,
                _targetSkills,
                _missingSkills
            );

            // Assert
            Assert.Contains(recommendations, r => 
                r.Reason.Contains("Azure") || 
                r.Reason.Contains("Design Patterns"));
        }

        [Fact]
        public async Task GenerateRecommendationsAsync_ShouldReturnFiveRecommendations()
        {
            // Arrange
            var openAIService = new OpenAIService();

            // Act
            var recommendations = await openAIService.GenerateRecommendationsAsync(
                _testEmployee,
                _testTargetRole,
                _currentSkills,
                _targetSkills,
                _missingSkills
            );

            // Assert
            Assert.Equal(5, recommendations.Count);
        }
    }
}