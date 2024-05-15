using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPatientHistoryMedicalAnalysisRepository
    {
        public void Create(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Update(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Delete(int patientHistoryId, int analysisId);
        public PatientHistoryMedicalAnalysis GetById(int patientHistoryId, int analysisId);
        public List<PatientHistoryMedicalAnalysis> GetAll();

        public List<PatientHistoryMedicalAnalysis> GetAll_AnalysisByPatientHistoryId(int patientHistoryId);

    }
}
