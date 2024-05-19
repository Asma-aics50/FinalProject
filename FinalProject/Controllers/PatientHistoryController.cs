using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels.PatientHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class PatientHistoryController : Controller
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
        public PatientHistoryController(

        IPatientRepositry patientRepositry,
          IDoctorRepositry doctorRepositry,
          IEmployeeRepositry employeeRepositry,
          IBookedAppointmentsRepositry bookedAppointmentsRepositry,
           IPatientHistoryRepositry patientHistoryRepositry,
          UserManager<ApplicationUser> userManager,
        IDrugRepositry drugRepositry,
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
            this.userManager = userManager;
            this.drugRepositry = drugRepositry;
            this.prescriptionRepository = prescriptionRepository;
            this.medicalAnalysisRepositry = medicalAnalysisRepositry;
            this.patientHistoryMedicalAnalysisrRepositry = patientHistoryMedicalAnalysisrRepositry;
            this.doctorPatientRepositry = doctorPatientRepositry;
        }

        [Authorize(Roles = "Doctor")]

        public IActionResult AllPatientHistory(int id)
        {
            string doctorUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int doctorId = doctorRepositry.FindByUserId(doctorUserId).Id;

            List<FullPatientHistoryViewModel> patientHistorVMs = patientHistoryRepositry.FindePatinetHistoriesByDoctorAndPatientIds(doctorId,id).Select(MapRepositry.MapToFullPatientHistoryVM).ToList();

            return View(patientHistorVMs);

        }

        [Authorize(Roles = "Patient")]

        public IActionResult PatientHistories()
        {
            string patientUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int patientId = patientRepositry._GetByUserId(patientUserId).Id;

            List<PatientHistoriesViewModel> patientHistoriesVMs = patientHistoryRepositry.Find_All_ByPatientId(patientId).Select(MapRepositry.MapToPatientHistoriesVM).ToList();
            return View(patientHistoriesVMs);

        }


    }
}
