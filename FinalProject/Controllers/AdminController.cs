using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        IPatientRepositry patientRepositry;
           IDoctorRepositry doctorRepositry;
              IEmployeeRepositry employeeRepositry;
        public AdminController(
              IPatientRepositry patientRepositry,
              IDoctorRepositry doctorRepositry,
              IEmployeeRepositry employeeRepositry
           )
        {
            this.patientRepositry = patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry = employeeRepositry;
        }

        public IActionResult Index()
        {
            ViewData["DoctorsNum"]=doctorRepositry.GetAll().ToList().Count();
            ViewData["PatientsNum"]=patientRepositry.GetAll().ToList().Count();

            return View();
        }

        public IActionResult AllDoctors()
        {
            
            List<AllDoctorsViewModel> doctorsVM =doctorRepositry.GetAll_Departments_User().Select(MapRepositry.MapToAllDoctorVM).ToList();


            return View(doctorsVM);
        }

        //
         public IActionResult DoctorDetails(int id)
         {
            return View();

         }





    }
}
