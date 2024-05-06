using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers

{
    [Authorize(Roles = "Admin")]

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

        public IActionResult AllPatients()
        {

            List<AllPatientViewModel> patientsVM = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToAllPatientsVM).ToList();

            return View(patientsVM);
        }








    }
}
