# Career Path Recommender

## Problem
Employees often struggle to identify the skills and learning paths needed to advance their careers or transition to new roles. Organizations need a way to help employees understand their current skill gaps and receive actionable, personalized recommendations for growth.

## Solution
Career Path Recommender is a web application that enables employees to:
- View their current skills and job role
- Select a target job role
- See the skill gaps between their current and target roles
- Receive AI-powered recommendations (courses, mentors, projects) to close those gaps
- Manage and update their skills profile

The system leverages OpenAI to generate tailored recommendations based on each employee's unique profile and goals.

## Features
- Secure authentication and registration
- Profile management (skills, job role, contact info)
- Role selection and skill gap analysis
- AI-driven recommendations (courses, mentors, projects)
- Export recommendations to PDF
- Admin/employee separation (optional)
- Modern, responsive UI

## Tech Stack
- **.NET 9** (ASP.NET Core Razor Pages)
- **Entity Framework Core** (SQL Server)
- **Serilog** (logging)
- **OpenAI/Azure OpenAI** (recommendation engine)
- **Bootstrap 5** (UI)
- **xUnit, Moq** (testing)

## Project Structure
- `CareerPathRecommender.Web` - Main web application (features, infrastructure, models, UI)
- `CareerPathRecommender.Tests` - Automated tests (xUnit)

## Getting Started
1. Clone the repository
2. Set up the database connection string in `appsettings.json`
3. Run database migrations
4. Run the application: `dotnet run --project CareerPathRecommender.Web`
5. Access the app at `https://localhost:5001`

## License
MIT
