using FinalProject.IRepositry;
using FinalProject.Services;
using FinalProject.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepositry departmentRepositry;
        IDoctorRepositry doctorRepositry;
        public DepartmentController(IDepartmentRepositry departmentRepositry, IDoctorRepositry doctorRepositry)
        {

            this.departmentRepositry = departmentRepositry;
            this.doctorRepositry = doctorRepositry;
        }
        public IActionResult Index()
        {
            List<DepartmentViewModel> Departments = departmentRepositry.GetAll().Where(e=>e.Id!=1&& e.Id!=2).Select(MapRepositry.MapToDeptVM).ToList();

            ViewBag.doctors = doctorRepositry.GetAll_Departments_User().Select(MapRepositry.MapToDoctorsVM).ToList();

            return View(Departments);
        }
    }
}
