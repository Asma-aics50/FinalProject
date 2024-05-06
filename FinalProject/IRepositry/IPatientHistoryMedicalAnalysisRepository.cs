using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPatientHistoryMedicalAnalysisRepository
    {
        public void Create(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Update(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Delete(int patientHistoryId,int  medicalAnaylsisId);
        public PatientHistoryMedicalAnalysis GetById(int patientHistoryId, int medicalAnaylsisId);
        public List<PatientHistoryMedicalAnalysis> GetAll();

    }
}
