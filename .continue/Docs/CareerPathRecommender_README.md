# Career Path Recommender Prototype

## 🚀 Overview
Employees often lack visibility into career growth opportunities.  
This prototype recommends **tailored learning paths, certifications, mentors, or projects** using AI and skill gap analysis.

using **.NET Core + Azure OpenAI + SQL Server**.  
Focus: **Prototype clarity, AI integration, and usability**.

---

## 🎯 Objectives
- Input: Mocked employee skill profile (SQL Server DB).
- Output: Personalized recommendations (e.g., Udemy courses, mentors, projects).
- Bonus: Explain *why recommended* (skill gap analysis using AI).
- Deliverables:  
  - Working demo (runs locally).  
  - Recorded demo (max 5 min).  
  - One-page summary (this file).  

---

## 📐 Architecture

We use **Vertical Slice Architecture** with a **light abstraction layer**:
- Each **feature** has its own handler (`IHandler` + implementation).
- Controllers depend on **interfaces, not concrete handlers** → testable & loosely coupled.
- AI integration lives inside the **Recommendation slice** only.
- Can evolve into full **Clean Architecture** if needed.

### Structure

```
CareerPathRecommender/
│
├── CareerPathRecommender.Web/       → ASP.NET Core Web (UI + API)
│   ├── Controllers/                 → Thin controllers
│   │   ├── EmployeeController.cs
│   │   └── RecommendationController.cs
│   │
│   ├── Features/                    → Vertical slices
│   │   ├── Employees/
│   │   │   ├── GetEmployeeProfile.cs
│   │   │   └── UpdateEmployeeSkills.cs
│   │   │
│   │   ├── Recommendations/
│   │   │   ├── IGetRecommendationsHandler.cs
│   │   │   ├── GetRecommendationsHandler.cs
│   │   │   └── RecommendationDto.cs
│   │   │
│   │   └── Auth/
│   │       ├── Login.cs
│   │       └── Register.cs
│   │
│   ├── Infrastructure/              → Cross-cutting services
│   │   ├── Data/
│   │   │   ├── AppDbContext.cs
│   │   │   └── SeedData.cs
│   │   ├── Services/
│   │   │   ├── OpenAIService.cs     → Azure OpenAI integration
│   │   │   └── EmailService.cs
│   │   └── Logging/
│   │       └── SerilogConfig.cs
│   │
│   ├── Models/                      → Shared entities
│   │   ├── Employee.cs
│   │   ├── Skill.cs
│   │   ├── Role.cs
│   │   └── Recommendation.cs
│   │
│   ├── Views/                       → Razor Views (Bootstrap + Chart.js)
│   │   ├── Employees/
│   │   └── Recommendations/
│   │
│   ├── appsettings.json
│   └── Program.cs
│
├── CareerPathRecommender.Tests/     → Test project
│   ├── EmployeesTests/
│   ├── RecommendationsTests/
│   └── Mocks/
│
└── README.md                        → This file
```

---

## 🔑 Key Features
- **Vertical Slices**: Each feature contains its own request/response/handler.  
- **AI Integration**: `OpenAIService` calls Azure OpenAI API for recommendations & explanations.  
- **Skill Gap Analysis**: AI explains missing skills for target roles.  
- **SQL Server Backend**: Stores employees, skills, roles, and recommendations.  
- **UI**: Simple MVC views with Bootstrap + Chart.js for visualization.  
- **Notifications**: Email via free SMTP (or mock).  

---

## 🧪 Testing & Quality
- **Unit Tests**: For feature handlers (mock DB & AI).  
- **Integration Tests**: For EF Core + controller endpoints.  
- **Code Coverage Reports**: Collected via `coverlet` + `ReportGenerator`.  
- **Error Handling & Logging**: Centralized with Serilog.  

---

## 🔮 Extra Points
- Scalability: Can extend to **multi-tenant** by adding TenantId to DB entities.  
- Offline caching: Local JSON store fallback for recommendations.  
- Export/Share: Recommendations can be exported to PDF or email.  
- AI: Runs via **Azure OpenAI (MSDN free subscription)**.  

---

## 📊 Architecture Diagram

```
┌──────────────────────────────┐
│         Presentation          │
│   Controllers + Views (UI)    │
└───────────────▲──────────────┘
                │
┌───────────────┴──────────────┐
│          Features             │
│   - Employees Slice           │
│   - Recommendations Slice     │
│   - Auth Slice                │
└───────────────▲──────────────┘
                │
┌───────────────┴──────────────┐
│       Infrastructure          │
│   - EF Core + SQL Server      │
│   - OpenAIService (Azure AI)  │
│   - Email/Logging             │
└───────────────▲──────────────┘
                │
┌───────────────┴──────────────┐
│            Models             │
│ Employee, Skill, Role,        │
│ Recommendation (shared)       │
└──────────────────────────────┘
```

---

## 📝 Next Steps (Beyond Prototype)
- Migrate to **Clean Architecture** with Domain Layer.  
- Add **authentication/roles** for managers vs. employees.  
- Enhance UI/UX for better visualization of skill gaps.  
- Connect to **real LMS APIs (Udemy, Coursera, LinkedIn Learning)**.  

---


