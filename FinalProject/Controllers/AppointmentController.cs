using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using FinalProject.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Controllers
{
    public class AppointmentController : Controller
    {
        IPatientRepositry patientRepositry;
        IDoctorRepositry doctorRepositry;
        IEmployeeRepositry employeeRepositry;
        IBookedAppointmentsRepositry bookedAppointmentsRepositry;

        public AppointmentController(

        IPatientRepositry patientRepositry,
          IDoctorRepositry doctorRepositry,
          IEmployeeRepositry employeeRepositry,
          IBookedAppointmentsRepositry bookedAppointmentsRepositry

        )
        {
            this.patientRepositry = patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry = employeeRepositry;
            this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPatientsAppointment()
        {

            List<AllPatientsAppointmentViewModel> AllPatientsAppointmentVM = bookedAppointmentsRepositry.GetAllAppointments_Patient_Doctor().
           Select(MapRepositry.MapToAllPatientsAppointmentVM).ToList();

            return View(AllPatientsAppointmentVM);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Doctors = doctorRepositry.GetAll_User().Select(MapRepositry.MapToCreateAppointmentDoctors).ToList();
            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();

            return View();

        }
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CreateEditAppointmentViewModel appointmentVM)
        {
            if (ModelState.IsValid)
            {
                //Map
                BookedAppointment appointment = MapRepositry.MapToBookedAppointment(appointmentVM);

                //Create
                bookedAppointmentsRepositry.Create(appointment);

                //Redirect
                return RedirectToAction("AllPatientsAppointment", "Appointment");
            }

            ViewBag.Doctors = doctorRepositry.GetAll_User().Select(MapRepositry.MapToCreateAppointmentDoctors).ToList();
            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Doctors = doctorRepositry.GetAll_User().Select(MapRepositry.MapToCreateAppointmentDoctors).ToList();
            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();

            var appointmentVM = MapRepositry.MapToCreateEditAppointmentVM(bookedAppointmentsRepositry.GetOne_Doctor_Patient(id));

            return View(appointmentVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateEditAppointmentViewModel appointmentVM)
        {
            if (ModelState.IsValid)
            {
                var appointment = MapRepositry.MapToBookedAppointment(appointmentVM);

                bookedAppointmentsRepositry.Update(appointment);
                return RedirectToAction("AllPatientsAppointment");

            }
            ViewBag.Doctors = doctorRepositry.GetAll_User().Select(MapRepositry.MapToCreateAppointmentDoctors).ToList();
            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();
            return View();
        }

        [Authorize(Roles = "Admin")]
       
        public IActionResult Delete(int id)
        {
            bookedAppointmentsRepositry.Delete(id);
            return RedirectToAction("AllPatientsAppointment");
        }
    }
}