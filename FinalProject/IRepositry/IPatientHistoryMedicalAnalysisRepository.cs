using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPatientHistoryMedicalAnalysisRepository
    {
        public void Create(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Update(PatientHistoryMedicalAnalysis patientHistoryMedicalAnalysis);
        public void Delete(int id);
        public PatientHistoryMedicalAnalysis GetById(int id);
        public List<PatientHistoryMedicalAnalysis> GetAll();

    }
}
