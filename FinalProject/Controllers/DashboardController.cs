using FinalProject.IRepositry;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DashboardController : Controller
    {
      
            IPatientRepositry patientRepositry;
            IDoctorRepositry doctorRepositry;
        IBookedAppointmentsRepositry bookedAppointmentsRepositry;



            public DashboardController(
                  IPatientRepositry patientRepositry,
                  IDoctorRepositry doctorRepositry,
                  IBookedAppointmentsRepositry bookedAppointmentsRepositry
               )
            {
                this.patientRepositry = patientRepositry;
                this.doctorRepositry = doctorRepositry;
                this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
            }

            public IActionResult AdminIndex()
            {
                ViewData["DoctorsNum"] = doctorRepositry.GetAll().ToList().Count();
                ViewData["PatientsNum"] = patientRepositry.GetAll().ToList().Count();
                return View();

            }
            public IActionResult DoctorIndex()
            {
                ViewData["DoctorsNum"] = doctorRepositry.GetAll().ToList().Count();
                ViewData["PatientsNum"] = patientRepositry.GetAll().ToList().Count();
                return View();
            }
        public IActionResult PatientIndex()
            {
                
                return View();
            }
        }
    }
