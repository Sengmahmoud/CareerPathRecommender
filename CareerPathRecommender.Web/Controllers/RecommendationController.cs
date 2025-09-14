using CareerPathRecommender.Web.Features.Employees;
using CareerPathRecommender.Web.Features.Recommendations;
using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Infrastructure.Services;
using CareerPathRecommender.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerPathRecommender.Web.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly IGetRecommendationsHandler _handler;
        private readonly AppDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly PdfExportService _pdfExportService;
        int targetId = 0;
        public RecommendationController(IGetRecommendationsHandler handler, AppDbContext context, UserManager<Employee> userManager, PdfExportService pdfExportService)
        {
            _handler = handler;
            _context = context;
            _userManager = userManager;
            _pdfExportService = pdfExportService;

        }

        // Show role selection dropdown
        public async Task<IActionResult> Index(string employeeId)
        {
           var user = await _userManager.GetUserAsync(User);
            employeeId = user?.Id;

            var employee = await _context.Employees
                .Include(e => e.EmployeeSkills)
                .ThenInclude(es => es.Skill)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            // Get all job roles for dropdown
            var jobRoles = await _context.JobRoles.ToListAsync();

            // Pass employee and job roles to view
            var viewModel = new RecommendationViewModel
            {
                Employee = employee,
                JobRoles = jobRoles
            };

            return View(viewModel);
        }

        // Handle form submission with selected target role
        [HttpPost]
        public async Task<IActionResult> GetRecommendations(string employeeId, int targetRoleId)
        {
            
            var recommendations = await _handler.GetRecommendationsForEmployee(employeeId, targetRoleId);
            TempData["RecommendationsJson"] = JsonSerializer.Serialize(recommendations);
            TempData["TargetRoleId"] = targetRoleId;
            return View("Recommendations", recommendations);
        }
        public async Task<IActionResult> ExportPdf()
        {
            var employee = await _userManager.GetUserAsync(User);
            employee.JobRole = await _context.JobRoles.FindAsync((int)(TempData["TargetRoleId"] ?? 0));

            if (TempData["RecommendationsJson"] is string recJson)
            {
                var recommendations = JsonSerializer.Deserialize<List<RecommendationDto>>(recJson);

                var pdfBytes = _pdfExportService.GenerateRecommendationsPdf(
                    employee.FullName,
                    employee.JobRole?.Title ?? "N/A",
                    recommendations
                );

                return File(pdfBytes, "application/pdf", $"Recommendations_{employee.FullName}.pdf");
            }

            return RedirectToAction("Index"); // fallback
        }
    }

   
}
