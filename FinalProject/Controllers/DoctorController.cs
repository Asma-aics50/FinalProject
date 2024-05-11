using FinalProject.IRepositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DoctorController : Controller
    {
        
        IDoctorRepositry doctorRepositry;
        
        public DoctorController(
           
            IDoctorRepositry doctorRepositry
           )
        {
           
            this.doctorRepositry = doctorRepositry;
           }

        public IActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "Admin, Doctor")]
        public IActionResult AllDoctors()
        {

            List<AllDoctorsViewModel> doctorsVM = doctorRepositry.GetAll_Departments_User().Select(MapRepositry.MapToAllDoctorVM).ToList();
            if (User.IsInRole("Doctor"))
                ViewBag.Layout = "_DoctorLayout";
            else if (User.IsInRole("Admin"))
                ViewBag.Layout = "_AdminLayout";


            return View(doctorsVM);
        }
    }
}
