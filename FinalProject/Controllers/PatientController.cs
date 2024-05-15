using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using FinalProject.ViewModels.PatientHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class PatientController : Controller
    {

        IPatientRepositry patientRepositry;
        IDoctorRepositry doctorRepositry;
        IPatientHistoryRepositry patientHistoryRepositry;
        IDoctorPatientRepositry doctorPatientRepositry;
        public PatientController(
              IPatientRepositry patientRepositry,
              IDoctorRepositry doctorRepositry,
            IPatientHistoryRepositry patientHistoryRepositry
            ,
            IDoctorPatientRepositry doctorPatientRepositry

           )
        {
            this.patientRepositry = patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.patientHistoryRepositry = patientHistoryRepositry;
            this.doctorPatientRepositry = doctorPatientRepositry;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AllPatients()
        {

            List<AllPatientViewModel> patientsVM = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToAllPatientsVM).ToList();

            return View(patientsVM);
        }

        [Authorize(Roles = "Doctor")]
        public IActionResult FindPatientByDoctor()
        {
            string doctorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int doctorId = doctorRepositry.FindByUserId(doctorUserId).Id;

            List<AllPatientViewModel> AllPatients = doctorPatientRepositry.FindePatinetByDoctor(doctorId).Select(MapRepositry.MapToAllPatientsVM).ToList();

            return View(AllPatients);
          
        }

        public IActionResult PatientDetails(int id)
        {
            var patient = patientRepositry._GetByIdUser(id);
            PatientDetailsViewModel patientDetailsViewModel = new PatientDetailsViewModel()
            {
                Name = $"{patient.User.FirstName}{patient.User.LastName}",
                Email = patient.User.Email,
                Gender = patient.User.Gender,
                PhoneNumber = patient.User.PhoneNumber,
                BirthDate = patient.User.BirthDate

            };
            return View(patientDetailsViewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditPatient(int id)
        {
            var editpatient = patientRepositry._GetByIdUser(id);
            PatientDetailsViewModel patientDetailsViewModel = new PatientDetailsViewModel()
            {
                Name = $"{editpatient.User.FirstName}{editpatient.User.LastName}",
                Email = editpatient.User.Email,
                Gender = editpatient.User.Gender,
                PhoneNumber = editpatient.User.PhoneNumber,
                BirthDate = editpatient.User.BirthDate

            };
            if(editpatient == null)
            {
                return RedirectToAction("AllPatients");
            }
            return View(editpatient);  
        }

        [HttpPost]
        public IActionResult EditPatient(PatientDetailsViewModel patientDetails)
        {
            if (ModelState.IsValid)
            {
                patientRepositry.UpdateUserPatient(patientDetails);
                return RedirectToAction("AllPatients");
            }

            
            patientDetails.Name = $"{patientDetails.User.FirstName} {patientDetails.User.LastName}";

            return View(patientDetails);
        }




        [Authorize(Roles = "Admin")]
        public IActionResult DeletePatient(int id)
        {
            patientRepositry.Delete(id);
            return RedirectToAction("AllPatients");
        }
       

    }
}
