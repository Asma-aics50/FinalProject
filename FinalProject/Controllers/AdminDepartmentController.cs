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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var editdept = departmentRepositry.GetById(id);
            EditDepartmentViewModel editDeptView = new EditDepartmentViewModel()
            {
                Id = editdept.Id,
                Name = editdept.Name,
               
            };
            return View(editDeptView);
        }
        public IActionResult EditDepartment(EditDepartmentViewModel editDeptView)
        {
            if (ModelState.IsValid)
            {
                departmentRepositry.UpdateEditDept(editDeptView);
                return RedirectToAction("AllDepartments");
            }

            return View(editDeptView);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            departmentRepositry.Delete(id);
            return RedirectToAction("AllDepartments");
        }
        public IActionResult DepartmentDetails(int id)
        {
            var details = departmentRepositry.GetById(id);
            DepartmentDetailsViewModel detailsViewModel = new DepartmentDetailsViewModel()
            {
                Id = details.Id,
                Name = details.Name,
               
            };
            return View(detailsViewModel);
        }
    }
}
