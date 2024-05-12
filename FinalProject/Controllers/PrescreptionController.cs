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
        IPatientHistoryMedicalAnalysisRepository patientHistoryMedicalAnalysisrRepositry;
        IDoctorPatientRepositry doctorPatientRepositry;
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
            IPatientHistoryMedicalAnalysisRepository patientHistoryMedicalAnalysisrRepositry,
            IDoctorPatientRepositry doctorPatientRepositry

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
            this.patientHistoryMedicalAnalysisrRepositry = patientHistoryMedicalAnalysisrRepositry;
            this.doctorPatientRepositry = doctorPatientRepositry;
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

                
                prescreptionVM.DoctorId = doctorRepositry.FindByUserId(GetCurrentUserIdAsync().Result).Id;


                //1-Add patient history
                //1-1 map

                PatientHistory patientHistory = MapRepositry.MapToPatientHistory(prescreptionVM);
               

                //Add Doctor-Patient Rel

                DoctorPatient newDoctorPatient= new DoctorPatient { DoctorId = prescreptionVM.DoctorId, PatientId = prescreptionVM.PatientId, CreatedAt = DateTime.Now };
                doctorPatientRepositry.Create(newDoctorPatient);



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
                            DateTime = patientHistory.CreatedAt
                           
                        };

                        patientHistoryMedicalAnalysisrRepositry.Create(item);

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
    

        public IActionResult PrescreptionDetails(int id)
        {

            //patienHistory

             
            PatientHistory patientHistory= patientHistoryRepositry.Find_Patinet_UsrById(id);

            //Drugs

            List<Prescription> prescriptions = prescriptionRepository.GetAll_DrugByPatientHistoryId(id);

            //MEdical Analysis
            List<PatientHistoryMedicalAnalysis> analysis = patientHistoryMedicalAnalysisrRepositry.GetAll_AnalysisByPatientHistoryId(id);

            //Map

            PrescreptionDetailsViewModel prescreptionDetailsVM=MapRepositry.MapToPrescreptionDetailsVM(patientHistory);


            ViewData["Analysis"] = analysis.Select(MapRepositry.MapToAnalysisVM).ToList();
            ViewData["Drugs"]=prescriptions.Select(MapRepositry.MapToDrugVM).ToList();

            //Return

            return View(prescreptionDetailsVM);


        }
    }
}
