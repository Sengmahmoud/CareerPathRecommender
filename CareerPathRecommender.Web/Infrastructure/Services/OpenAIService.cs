  using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CareerPathRecommender.Web.Models;
using CareerPathRecommender.Web.Features.Recommendations;
using System.Collections.Generic;

namespace CareerPathRecommender.Web.Infrastructure.Services
{
    public class OpenAIService
    {
        private readonly string _endpoint = "https://cairoict-ai.openai.azure.com/openai/deployments/CairoICT-AI/chat/completions?api-version=2025-01-01-preview";
        private readonly string _apiKey = "e05dd71d6b584c9bab15e04e17bc2e6a";
        private readonly HttpClient _httpClient;

        public OpenAIService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<RecommendationDto>> GenerateRecommendationsAsync(
            Employee employee,
            JobRole targetRole,
            List<string> currentSkills,
            List<string> targetSkills,
            List<string> missingSkills)
        {
            // 1. Build messages payload
            var currentSkillsStr = string.Join(", ", currentSkills);
            var targetSkillsStr = string.Join(", ", targetSkills);
            var missingSkillsStr = string.Join(", ", missingSkills);

            var prompt = $@"
You are a career advisor AI.
Employee: {employee.FullName}, Current Job Role: {employee.JobRole.Title}, Target Job Role: {targetRole.Title}
Current Skills: {currentSkillsStr}
Target Skills: {targetSkillsStr}
Missing Skills: {missingSkillsStr}



 Task:
    - Recommend 5 personalized items, focusing on courses (but include mentors or projects if helpful).
    - Each recommendation must explain why, based on missing skills.
    - Return **only** a JSON array in this format:
    [
      {{""Type"":""Course"",""Title"":""..."",""Reason"":""...""}}
    ]";

            var requestBody = new
            {
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                max_tokens = 500,
                temperature = 0.7,
                top_p = 1,
                model = "CairoICT-AI"
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            // 2. Send POST request
            var response = await _httpClient.PostAsync(_endpoint, jsonContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            // 3. Parse response (simplified)
            // The Azure OpenAI Chat API returns choices[0].message.content
            using var doc = JsonDocument.Parse(responseContent);
            var text = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            List<RecommendationDto> recommendations;
            try
            {
                text = text.Replace("```json", "").Replace("```", "").Trim();
                recommendations = JsonSerializer.Deserialize<List<RecommendationDto>>(text);
            }
            catch
            {
                recommendations = new List<RecommendationDto>();
            }

            return recommendations;
        }
    }
}
