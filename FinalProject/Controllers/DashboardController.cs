using FinalProject.IRepositry;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DashboardController : Controller
    {
      
            IPatientRepositry patientRepositry;
            IDoctorRepositry doctorRepositry;
        IBookedAppointmentsRepositry bookedAppointmentsRepositry;
        IEmployeeRepositry employeeRepositry;
        IPatientHistoryRepositry PatientHistoryRepositry;
        IBillRepositry BillRepositry;
            public DashboardController(
                  IPatientRepositry patientRepositry,
                  IDoctorRepositry doctorRepositry,
                  IBookedAppointmentsRepositry bookedAppointmentsRepositry,
                  IEmployeeRepositry employeeRepositry,
                  IPatientHistoryRepositry patientHistoryRepositry,
                  IBillRepositry BillRepositry

               )
            {
                this.patientRepositry = patientRepositry;
                this.doctorRepositry = doctorRepositry;
                this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
                this.employeeRepositry = employeeRepositry;
                this.PatientHistoryRepositry = patientHistoryRepositry;
            this.BillRepositry = BillRepositry;
            }

            public IActionResult AdminIndex()
            {
                ViewData["DoctorsNum"] = doctorRepositry.GetAll().ToList().Count();
                ViewData["PatientsNum"] = patientRepositry.GetAll().ToList().Count();
                ViewData["AppointmnetsNum"] = bookedAppointmentsRepositry.GetAll().ToList().Count();
                ViewData["employeesNum"] = employeeRepositry.GetAll().ToList().Count();
                ViewData["CaseStudies"]=PatientHistoryRepositry.GetAll().ToList().Count();
                 ViewData["Invoices"]=PatientHistoryRepositry.GetAll().ToList().Count();
                



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
