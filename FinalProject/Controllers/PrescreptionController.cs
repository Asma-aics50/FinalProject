using FinalProject.Data.Enum;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels.PatientHistory;
using FinalProject.ViewModels.Prescreption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class PrescreptionController : Controller
    {
        IPatientRepositry patientRepositry;
        IDoctorRepositry doctorRepositry;
        IEmployeeRepositry employeeRepositry;
        IBookedAppointmentsRepositry bookedAppointmentsRepositry;
        IPatientHistoryRepositry patientHistoryRepositry; 
        UserManager<ApplicationUser> userManager;
        IDrugRepositry drugRepositry;
        IPrescriptionRepositry prescriptionRepository;
        IMedicalAnalysisRepositry medicalAnalysisRepositry;
        IPatientHistoryMedicalAnalysisRepository patientHistoryMedicalAnalysis;
        public PrescreptionController(

        IPatientRepositry patientRepositry,
          IDoctorRepositry doctorRepositry,
          IEmployeeRepositry employeeRepositry,
          IBookedAppointmentsRepositry bookedAppointmentsRepositry,
           IPatientHistoryRepositry patientHistoryRepositry,
          UserManager<ApplicationUser> userManager,
        IDrugRepositry drugRepositry ,
        IPrescriptionRepositry prescriptionRepository,

        IMedicalAnalysisRepositry medicalAnalysisRepositry,
            IPatientHistoryMedicalAnalysisRepository patientHistoryMedicalAnalysis
        
        )
        {
            this.patientRepositry = patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry = employeeRepositry;
            this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
            this.patientHistoryRepositry = patientHistoryRepositry;    
            this.userManager= userManager;
            this.drugRepositry=drugRepositry;
            this.prescriptionRepository= prescriptionRepository;
            this.medicalAnalysisRepositry = medicalAnalysisRepositry;
            this.patientHistoryMedicalAnalysis = patientHistoryMedicalAnalysis;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(patientHistoryRepositry.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();
            ViewBag.Drugs = drugRepositry.GetAll().ToList();
            ViewBag.Analysis = medicalAnalysisRepositry.GetAll().ToList();

            return View();
        }

        private async Task<string> GetCurrentUserIdAsync()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            return await userManager.GetUserIdAsync(user);
        }
        [HttpPost]
            //public IActionResult Create(CreateViewModel prescreptionVM,/*string[] instructionInput,int [] drugSelect*/)
            public IActionResult Create(CreateViewModel prescreptionVM, int[] drugSelectList,string[] instructions,int[] medicalAnalysisList)
            {
            if(ModelState.IsValid)
            {
                //1-Add patient history
                //1-1 map

                prescreptionVM.DoctorId = doctorRepositry.FindByUserId(GetCurrentUserIdAsync().Result).Id;

                PatientHistory patientHistory = MapRepositry.MapToPatientHistory(prescreptionVM);

                //1-2create patientHistory

                patientHistoryRepositry.Create(patientHistory);

                //2- add prescreption

                int patienthistoryId = patientHistoryRepositry.FindByPatientIdAndDate(patientHistory.CreatedAt, patientHistory.PatientId).Id;
                if (drugSelectList.Count() > 0)
                {

                    for (int i = 0; i < drugSelectList.Count(); i++) 
                    {
                        Prescription prescriptionItem = new Prescription()
                        {
                            PatientHistoryId = patienthistoryId,
                            DrugId = drugSelectList[i],
                            DrugInstruction = instructions[i],
                        };
                        prescriptionRepository.Create(prescriptionItem);
                    
                    }
                }

        
                if (medicalAnalysisList.Count() > 0)
                {
                    for (int i = 0; i < medicalAnalysisList.Count(); i++)
                    {
                        PatientHistoryMedicalAnalysis item = new PatientHistoryMedicalAnalysis()
                        {

                            PatientHistoryId = patienthistoryId,
                            MedicalAnaylsisId = medicalAnalysisList[i],
                            DateTime = patientHistory.CreatedAt,
                            Result = ""

                        };

                        patientHistoryMedicalAnalysis.Create(item);

                    }
                }

                //4- create appointemnt
                if (prescreptionVM.ReExaminatoinDate!=null)
                {
                    BookedAppointment bookedAppointment = MapRepositry.MapToAutoBookedAppointment(prescreptionVM);
                    bookedAppointmentsRepositry.Create(bookedAppointment);
                                    
                }

                //5- redirect
                return RedirectToAction("Index");

            }

            ViewBag.Patients = patientRepositry.GetAll_Patients_User().Select(MapRepositry.MapToCreateAppointmentPatients).ToList();
            
            return View();
        }

        [Authorize(Roles = "Doctor")]
      
        public IActionResult DoctorCaseStudies()
        {
            string doctorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            int doctorId = doctorRepositry.FindByUserId(doctorUserId).Id;

            List<PatientHistoryViewModel> patientHistorVMs = patientHistoryRepositry.FindePatinetByDoctor(doctorId).Select(MapRepositry.MapToPatientHistoryVM).ToList();

            return View(patientHistorVMs);

        }
    }
}
