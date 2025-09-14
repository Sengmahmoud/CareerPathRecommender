using Microsoft.EntityFrameworkCore;
using CareerPathRecommender.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace CareerPathRecommender.Web.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Employee>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<JobRoleSkill> JobRoleSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rename Identity tables
            modelBuilder.Entity<Employee>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");

            // Composite key for many-to-many
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(es => new { es.EmployeeId, es.SkillId });

            // Configure JobRoleSkill entity
            modelBuilder.Entity<JobRoleSkill>()
                .HasOne(jrs => jrs.JobRole)
                .WithMany(jr => jr.JobRoleSkills)
                .HasForeignKey(jrs => jrs.JobRoleId);

            modelBuilder.Entity<JobRoleSkill>()
                .HasOne(jrs => jrs.Skill)
                .WithMany(s => s.JobRoleSkills)
                .HasForeignKey(jrs => jrs.SkillId);
        }
    }
}
