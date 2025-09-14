using CareerPathRecommender.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CareerPathRecommender.Web.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Skip seeding if data exists
            if (context.Employees.Any()) return;

            // 1. Seed JobRoles
            var jobRoles = new List<JobRole>
            {
                new JobRole { Title = "Software Engineer" },
                new JobRole { Title = "Senior Software Engineer" },
                new JobRole { Title = "Software Engineering Specialist" },
                new JobRole { Title = "Software Engineering Senior Specialist" },
                new JobRole { Title = "Principal Software Engineer" },
                new JobRole { Title = "Senior Principal Software Engineer" },
                new JobRole { Title = "Software Engineering Expert" },
                new JobRole { Title = "Software Engineering Senior Expert" },
                new JobRole { Title = "Distinguished Software Engineering Expert" },
                new JobRole { Title = "Senior Distinguished Software Engineering Expert" },
                new JobRole { Title = "Solution Architect" },
                new JobRole { Title = "Senior Solution Architect" },
                new JobRole { Title = "Principal Solution Architect" },
                new JobRole { Title = "Distinguished Solution Architect" },
                new JobRole { Title = "Senior Distinguished Solution Architect" },
                new JobRole { Title = "Software Engineering Lead" },
                new JobRole { Title = "Software Engineering Senior Lead" },
                new JobRole { Title = "Software Engineering Manager" },
                new JobRole { Title = "Senior Software Engineering Manager" },
                new JobRole { Title = "Principal Software Engineering Manager" },
                new JobRole { Title = "Distinguished Software Engineering Manager" },
                new JobRole { Title = "Senior Distinguished Software Engineering Manager" },
                new JobRole { Title = "Frontend Developer" }
            };
            context.JobRoles.AddRange(jobRoles);
            context.SaveChanges();

            // 2. Seed Skills
            var skills = new List<Skill>
            {
                new Skill { Name = "C#" },
                new Skill { Name = "SQL" },
                new Skill { Name = "ASP.NET Core" },
                new Skill { Name = "Vue.js" },
                new Skill { Name = "Leadership" },
                new Skill { Name = "Microservices" },
                new Skill { Name = "Cloud platforms" },
                new Skill { Name = "Architecture patterns" },
                new Skill { Name = "Infrastructure" },
                new Skill { Name = "Networking" },
                new Skill { Name = "Security" },
                new Skill { Name = "DevOps" },
                new Skill { Name = "Agile" },
                new Skill { Name = "Waterfall" },
                new Skill { Name = "Self-discipline" },
                new Skill { Name = "Communication" },
                new Skill { Name = "Problem-solving" },
                new Skill { Name = "Teamwork" },
                new Skill { Name = "Time management" },
                new Skill { Name = "Adaptability" },
                new Skill { Name = "Analytical skills" },
                new Skill { Name = "Independence" },
                new Skill { Name = "Feedback" },
                new Skill { Name = "Rapid learning" },
                new Skill { Name = "Teaching" },
                new Skill { Name = "Growth mindset" },
                new Skill { Name = "Flexibility" },
                new Skill { Name = "Presentation" },
                new Skill { Name = "Mentoring" },
                new Skill { Name = "Negotiation" },
                new Skill { Name = "Management" }
            };
            context.Skills.AddRange(skills);
            context.SaveChanges();

            // // 3. Seed Employees
            // var employees = new List<Employee>
            // {
            //     new Employee
            //     {
            //         FullName = "Mahmoud Hassan",
            //         JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id
            //     },
            //     new Employee
            //     {
            //         FullName = "Sara Ahmed",
            //         JobRoleId = jobRoles.First(j => j.Title == "Frontend Developer").Id
            //     }
            // };
            // context.Employees.AddRange(employees);
            // context.SaveChanges();

            // // 4. Seed EmployeeSkill (many-to-many)
            // var employeeSkills = new List<EmployeeSkill>
            // {
            //     new EmployeeSkill
            //     {
            //         EmployeeId = employees.First(e => e.FullName == "Mahmoud Hassan").Id,
            //         SkillId = skills.First(s => s.Name == "C#").Id,
            //         Level = "Intermediate"
            //     },
            //     new EmployeeSkill
            //     {
            //         EmployeeId = employees.First(e => e.FullName == "Mahmoud Hassan").Id,
            //         SkillId = skills.First(s => s.Name == "SQL").Id,
            //         Level = "Intermediate"
            //     },
            //     new EmployeeSkill
            //     {
            //         EmployeeId = employees.First(e => e.FullName == "Sara Ahmed").Id,
            //         SkillId = skills.First(s => s.Name == "Vue.js").Id,
            //         Level = "Intermediate"
            //     },
            //     new EmployeeSkill
            //     {
            //         EmployeeId = employees.First(e => e.FullName == "Sara Ahmed").Id,
            //         SkillId = skills.First(s => s.Name == "Leadership").Id,
            //         Level = "Beginner"
            //     }
            // };
            // context.EmployeeSkills.AddRange(employeeSkills);
            // context.SaveChanges();

            // 5. Seed JobRoleSkill (many-to-many)
            var jobRoleSkills = new List<JobRoleSkill>
            {
                // Software Engineer
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Beginner"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Beginner"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Self-discipline").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Problem-solving").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Teamwork").Id,
                    Level = "Intermediate"
                },

                // Senior Software Engineer
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Time management").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Adaptability").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Analytical skills").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Intermediate"
                },

                // Software Engineering Specialist
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Analytical skills").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Independence").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Feedback").Id,
                    Level = "Intermediate"
                },

                // Software Engineering Senior Specialist
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Analytical skills").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Independence").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Specialist").Id,
                    SkillId = skills.First(s => s.Name == "Feedback").Id,
                    Level = "Intermediate"
                },

                // Principal Software Engineer
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Rapid learning").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Teaching").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Growth mindset").Id,
                    Level = "Advanced"
                },

                // Senior Principal Software Engineer
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Rapid learning").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Teaching").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Principal Software Engineer").Id,
                    SkillId = skills.First(s => s.Name == "Growth mindset").Id,
                    Level = "Advanced"
                },

                // Software Engineering Expert
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Flexibility").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Problem-solving").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Time management").Id,
                    Level = "Advanced"
                },

                // Software Engineering Senior Expert
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "Flexibility").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "Problem-solving").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Expert").Id,
                    SkillId = skills.First(s => s.Name == "Time management").Id,
                    Level = "Advanced"
                },

                // Distinguished Software Engineering Expert
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Rapid learning").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Teaching").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Growth mindset").Id,
                    Level = "Advanced"
                },

                // Senior Distinguished Software Engineering Expert
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "C#").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "SQL").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "ASP.NET Core").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Microservices").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Rapid learning").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Teaching").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Expert").Id,
                    SkillId = skills.First(s => s.Name == "Growth mindset").Id,
                    Level = "Advanced"
                },

                // Solution Architect
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Cloud platforms").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Architecture patterns").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Infrastructure").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Networking").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Security").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Presentation").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },

                // Senior Solution Architect
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Cloud platforms").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Architecture patterns").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Infrastructure").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Networking").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Security").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Presentation").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },

                // Principal Solution Architect
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Cloud platforms").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Architecture patterns").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Infrastructure").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Networking").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Security").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Presentation").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },

                // Distinguished Solution Architect
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Cloud platforms").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Architecture patterns").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Infrastructure").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Networking").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Security").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Presentation").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Management").Id,
                    Level = "Intermediate"
                },

                // Senior Distinguished Solution Architect
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Cloud platforms").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Architecture patterns").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Infrastructure").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Networking").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Security").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Presentation").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Solution Architect").Id,
                    SkillId = skills.First(s => s.Name == "Management").Id,
                    Level = "Intermediate"
                },

                // Software Engineering Lead
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Lead").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },

                // Software Engineering Senior Lead
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Senior Lead").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },

                // Software Engineering Manager
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Negotiation").Id,
                    Level = "Intermediate"
                },

                // Senior Software Engineering Manager
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Negotiation").Id,
                    Level = "Intermediate"
                },

                // Principal Software Engineering Manager
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Principal Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Negotiation").Id,
                    Level = "Intermediate"
                },

                // Distinguished Software Engineering Manager
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Negotiation").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Management").Id,
                    Level = "Advanced"
                },

                // Senior Distinguished Software Engineering Manager
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Architecture").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "DevOps").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Agile").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Waterfall").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Mentoring").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Communication").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Negotiation").Id,
                    Level = "Intermediate"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Senior Distinguished Software Engineering Manager").Id,
                    SkillId = skills.First(s => s.Name == "Management").Id,
                    Level = "Advanced"
                },

                // Frontend Developer
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Frontend Developer").Id,
                    SkillId = skills.First(s => s.Name == "Vue.js").Id,
                    Level = "Advanced"
                },
                new JobRoleSkill
                {
                    JobRoleId = jobRoles.First(j => j.Title == "Frontend Developer").Id,
                    SkillId = skills.First(s => s.Name == "Leadership").Id,
                    Level = "Beginner"
                }
            };
            context.JobRoleSkills.AddRange(jobRoleSkills);
            context.SaveChanges();
        }
    }
}
