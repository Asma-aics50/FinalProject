using FinalProject.Data;
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
    //[Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
              IPatientRepositry patientRepositry;
              IDoctorRepositry doctorRepositry;
              IEmployeeRepositry employeeRepositry;
              IBookedAppointmentsRepositry bookedAppointmentsRepositry;
        public AdminController(
              IPatientRepositry patientRepositry,
              IDoctorRepositry doctorRepositry,
              IEmployeeRepositry employeeRepositry,
              IBookedAppointmentsRepositry bookedAppointmentsRepositry
           )
        {
            this.patientRepositry = patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry = employeeRepositry;
            this.bookedAppointmentsRepositry= bookedAppointmentsRepositry;
        }

        public IActionResult Index()
        {
            ViewData["DoctorsNum"]=doctorRepositry.GetAll().ToList().Count();
            ViewData["PatientsNum"]=patientRepositry.GetAll().ToList().Count();

            return View();
        }


       
       







    }
}
