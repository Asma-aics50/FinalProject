using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositry
{
    public class PatientHistoryMedicalAnalysisRepositry :IPatientHistoryMedicalAnalysisRepository
    {
        HospitalManagementSystemDbContext context;
        public PatientHistoryMedicalAnalysisRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis)
        {


            var phma = GetById(patientHistoryMedicalAnalysis.PatientHistoryId, patientHistoryMedicalAnalysis.MedicalAnaylsisId);
            if (phma == null)
            {

                context.Add(patientHistoryMedicalAnalysis);
                context.SaveChanges();

            }
        }

        public void Delete(int patientHistoryId, int analysisId)
        {
            var phma = GetById(patientHistoryId,  analysisId);
            if (phma != null) 
            { 
                context.Remove(phma);
                context.SaveChanges();
            }
        }

        public List<PatientHistoryMedicalAnalysis> GetAll()
        {
            return context.PatientHistoryMedicalAnalyses.ToList();
        }
        public List<PatientHistoryMedicalAnalysis> GetAll_AnalysisByPatientHistoryId(int patientHistoryId)
        {
            return context.PatientHistoryMedicalAnalyses.Include(e=>e.MedicalAnaylsis).Where(e=>e.PatientHistoryId==patientHistoryId).ToList();
        }

        public PatientHistoryMedicalAnalysis GetById(int patientHistoryId, int analysisId)
        {

            return context.PatientHistoryMedicalAnalyses.FirstOrDefault(e=>e.PatientHistoryId==patientHistoryId && e.MedicalAnaylsisId==analysisId);
        }

        public void Update(PatientHistoryMedicalAnalysis _patientHistoryMedicalAnalysis)
        {
            var phma = GetById(_patientHistoryMedicalAnalysis.PatientHistoryId, _patientHistoryMedicalAnalysis.MedicalAnaylsisId);
            if (phma != null)
            {
                phma.Result = _patientHistoryMedicalAnalysis.Result;
            }
        }
    }
}
