using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

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
            context.Add(patientHistoryMedicalAnalysis);
            context.SaveChanges();
        }

        public void Delete(int patientHistoryId, int medicalAnaylsisId)
        {
            var phma = GetById( patientHistoryId, medicalAnaylsisId);
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

        public PatientHistoryMedicalAnalysis GetById(int patientHistoryId, int medicalAnaylsisId)
        {
            return context.Set<PatientHistoryMedicalAnalysis>().SingleOrDefault(e=>e.MedicalAnaylsisId ==medicalAnaylsisId&&e.PatientHistoryId ==patientHistoryId);
        }

        public void Update(PatientHistoryMedicalAnalysis _patientHistoryMedicalAnalysis)
        {
            var phma = GetById(_patientHistoryMedicalAnalysis.PatientHistoryId ,_patientHistoryMedicalAnalysis.MedicalAnaylsisId);
            if (phma != null) 
            {
                phma.DateTime = _patientHistoryMedicalAnalysis.DateTime;
                phma.Result = _patientHistoryMedicalAnalysis.Result;    
                phma.PatientHistoryId=_patientHistoryMedicalAnalysis.PatientHistoryId;
                phma.MedicalAnaylsisId = _patientHistoryMedicalAnalysis.MedicalAnaylsisId;
                context.SaveChanges();
            }
        }
    }
}
