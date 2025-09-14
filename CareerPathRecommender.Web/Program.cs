using CareerPathRecommender.Web.CustomeMiddelwre;
using CareerPathRecommender.Web.Features.Recommendations;
using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Infrastructure.Services;
using CareerPathRecommender.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
QuestPDF.Settings.License = LicenseType.Community;
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Information() 
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}"
    )
    .CreateLogger();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Identity
builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Register your RecommendationHandler
builder.Services.AddScoped<IGetRecommendationsHandler, GetRecommendationsHandler>();

// Register OpenAIService
builder.Services.AddScoped<OpenAIService>();
builder.Services.AddScoped<PdfExportService>();

// Register feature handlers for DI
builder.Services.AddScoped<CareerPathRecommender.Web.Features.Employees.GetEmployeeProfile>();
builder.Services.AddScoped<CareerPathRecommender.Web.Features.Employees.UpdateEmployeeSkills>();

var app = builder.Build();
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     SeedData.Initialize(services);
// }
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<RequestLoggingMiddleware>();

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
