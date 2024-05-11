using FinalProject.IRepositry;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class PatientController : Controller
    {

        IPatientRepositry patientRepositry;
     
        public PatientController(
              IPatientRepositry patientRepositry
           )
        {
            this.patientRepositry = patientRepositry;
        }


        //[Authorize(Roles = "Admin")]
            public IActionResult AllPatients()
        {

            List<AllPatientViewModel> patientsVM = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToAllPatientsVM).ToList();

            return View(patientsVM);
        }

    }
}
