using FinalProject.IRepositry;
using FinalProject.Models;
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
        public IActionResult DoctorDetails(int id)
        {
            var doctor = doctorRepositry._GetByIdUser(id);
            if (doctor == null || doctor.User == null)
            {
                return NotFound(); 
            }

            DoctorDetailsViewModel doctorDetailsViewModel = new DoctorDetailsViewModel()
            {
                Name = $"{doctor.User.FirstName} {doctor.User.LastName}",
                PhoneNumber = doctor.User.PhoneNumber,
                Email = doctor.User.Email,
                ShiftStartTime = doctor.ShiftStartTime,
                ShiftEndTime = doctor.ShiftEndTime,
                DepartmentId = doctor.DepartmentId,
                Gender = doctor.User.Gender,
                Salary = doctor.Salary,
                Specialist = doctor.Specialization,
                BirthDate = doctor.User.BirthDate,
                Department = doctor.Department.Name,
            };

            return View(doctorDetailsViewModel);
        }



    }
}
