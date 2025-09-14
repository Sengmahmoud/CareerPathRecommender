using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CareerPathRecommender.Web.Models;
using CareerPathRecommender.Web.Infrastructure.Data;
using System.Threading.Tasks;
using CareerPathRecommender.Web.Features.Employees;

namespace CareerPathRecommender.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly AppDbContext _context;
        private readonly GetEmployeeProfile _getEmployeeProfile;
        private readonly UpdateEmployeeSkills _updateEmployeeSkills;

        public EmployeeController(UserManager<Employee> userManager, AppDbContext context, GetEmployeeProfile getEmployeeProfile, UpdateEmployeeSkills updateEmployeeSkills)
        {
            _userManager = userManager;
            _context = context;
            _getEmployeeProfile = getEmployeeProfile;
            _updateEmployeeSkills = updateEmployeeSkills;
        }

   

        public async Task<IActionResult> ManageSkills()
        {
            var employee = await _getEmployeeProfile.HandleAsync(User);
            if (employee == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var viewModel = new ManageSkillsViewModel
            {
                Employee = employee,
                AllSkills = _context.Skills.ToList(),
                SelectedSkillIds = employee.EmployeeSkills.Select(es => es.SkillId).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageSkills(ManageSkillsViewModel model)
        {
            var employee = await _userManager.GetUserAsync(User);
            if (employee == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            await _updateEmployeeSkills.UpdateAsync(employee.Id, model.SelectedSkillIds);
            return RedirectToAction("Index", "Home");
        }
    }
}
