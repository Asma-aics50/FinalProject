using FinalProject.IRepositry;
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
       

    }
}
