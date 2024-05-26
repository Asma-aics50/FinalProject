using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AdminDepartmentController : Controller
    {
        IDepartmentRepositry departmentRepositry;
        IDoctorRepositry doctorRepositry;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        public AdminDepartmentController(IDepartmentRepositry departmentRepositry, IDoctorRepositry doctorRepositry, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.departmentRepositry = departmentRepositry;
            this.doctorRepositry = doctorRepositry;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDepartment()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDepartment(CreateDepartmentViewModel createDepartmentView)
        {

            Department Dept = new Department() { Id = createDepartmentView.Id, Name = createDepartmentView.Name};
            departmentRepositry.Create(Dept);


            return RedirectToAction("AllDepartments");
        }
        public IActionResult AllDepartments()
        {
            List<AllDepartmentViewModel> dept = departmentRepositry.GetAll().Select(MapRepositry.MapToAllDepartmentVM).ToList();

            return View(dept);
        }

    }
}
