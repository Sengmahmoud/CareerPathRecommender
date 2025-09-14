# CareerPathRecommender – Setup Checklist (Vertical Slices MVC)

This checklist guides you to set up the project following the agreed architecture and folder structure.

---

## 1. Create Solution & Projects

- Create project: **ASP.NET Core Web App (Model-View-Controller)** → Name: `CareerPathRecommender.Web`.
- Add new project: **xUnit Test Project** → Name: `CareerPathRecommender.Tests`.
- Add solution items: `README.md`.

✅ Validation: Solution Explorer shows `CareerPathRecommender.Web`, `CareerPathRecommender.Tests`.

---

## 2. Create Core Folders in Web Project
Inside `CareerPathRecommender.Web` add:

```
Controllers/
Features/
   ├── Employees/
   ├── Recommendations/
   └── Auth/
Infrastructure/
   ├── Data/
   ├── Services/
   └── Logging/
Models/
Views/
   ├── Employees/
   └── Recommendations/
```

✅ Validation: Folder structure matches your plan.

---

## 3. Add Models
In `Models/` create:
- `Employee.cs`
- `Skill.cs`
- `Role.cs`
- `Recommendation.cs`

Each is a **POCO** class for EF Core.

✅ Validation: Models compile.

---

## 4. Infrastructure Setup
In `Infrastructure/`:

- `Data/AppDbContext.cs` → DbContext with `DbSet<Employee>, DbSet<Skill>, DbSet<Recommendation>`.
- `Data/SeedData.cs` → Seeds demo users, roles, skills.
- `Services/OpenAIService.cs` → Wrapper for Azure OpenAI calls.
- `Services/EmailService.cs` → Uses SMTP/email API (for notifications).
- `Logging/SerilogConfig.cs` → Configures Serilog.

✅ Validation: App compiles and services registered in `Program.cs`.

---

## 5. Features (Vertical Slices)
### Employees
- `GetEmployeeProfile.cs` → Handler logic for fetching profile.
- `UpdateEmployeeSkills.cs` → Handler logic for updating skills.

### Recommendations
- `IGetRecommendationsHandler.cs` → Interface.
- `GetRecommendationsHandler.cs` → Business logic (calls OpenAIService + DB).
- `RecommendationDto.cs` → DTO for returning recommendations.

### Auth
- `Login.cs` → Handler logic for login.
- `Register.cs` → Handler logic for register.

✅ Validation: Handlers have plain C# classes (no mediator).

---

## 6. Controllers (Thin)
- `Controllers/EmployeeController.cs` → Calls `GetEmployeeProfile` and `UpdateEmployeeSkills`.
- `Controllers/RecommendationController.cs` → Calls `GetRecommendationsHandler`.

✅ Validation: Controllers just forward to handlers.

---

## 7. Views
- `Views/Employees/Index.cshtml` → Profile view.
- `Views/Employees/Edit.cshtml` → Skill editing.
- `Views/Recommendations/Index.cshtml` → Recommendations (Bootstrap + Chart.js for skill gaps).

✅ Validation: MVC app runs and renders Razor pages.

---

## 8. Configuration
- Add connection string in `appsettings.json`.
- In `Program.cs`:
  - Register DbContext, Identity, Serilog, services (OpenAI, Email).
  - Add MVC routing.

✅ Validation: `dotnet ef database update` creates DB, app runs.

---

## 9. Tests
In `CareerPathRecommender.Tests/`:
- `EmployeesTests/EmployeeHandlerTests.cs`
- `RecommendationsTests/RecommendationHandlerTests.cs`
- `Mocks/FakeOpenAIService.cs`

✅ Validation: Tests run in Test Explorer.

---

## 10. Docs
- Add `README.md` with:
  - Problem, solution, architecture diagram, setup steps.
  - Demo instructions.

---

✅ With this checklist, you’ll have a working prototype aligned with MVC + vertical slices, ready for demo within 48 hours.
