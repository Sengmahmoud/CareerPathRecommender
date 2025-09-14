using CareerPathRecommender.Web.Features.Employees;
using CareerPathRecommender.Web.Infrastructure.Data;
using CareerPathRecommender.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CareerPathRecommender.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<Employee> _userManager;
    private readonly AppDbContext _context;
    private readonly GetEmployeeProfile _getEmployeeProfile;
    private readonly UpdateEmployeeSkills _updateEmployeeSkills;
    public HomeController(ILogger<HomeController> logger, UserManager<Employee> userManager,
        AppDbContext appContext,GetEmployeeProfile getEmployeeProfile, UpdateEmployeeSkills updateEmployeeSkills)
    {
        _logger = logger;
        _userManager = userManager;
        _context = appContext;
        _getEmployeeProfile = getEmployeeProfile;
        _updateEmployeeSkills = updateEmployeeSkills;
    }

    public async Task<IActionResult> Index()
    {
        var employee = await _getEmployeeProfile.HandleAsync(User);
        if (employee == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        return View(employee);
    }

 
}
