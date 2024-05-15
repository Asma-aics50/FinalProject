using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPatientHistoryRepositry
    {
        public void Create(PatientHistory patientHistory);
        public void Update(PatientHistory patientHistory);
        public void Delete(int id);
        public PatientHistory Get(int id);
        public List<PatientHistory> GetAll();
        public PatientHistory FindByPatientIdAndDate(DateTime createdAt,int patientId);
        public List<PatientHistory> FindePatinetByDoctor(int doctorId);
        public List<PatientHistory> FindePatinetHistoriesByDoctorAndPatientIds(int doctorId, int patientId);
        public PatientHistory Find_Patinet_UsrById(int id);

    }
}
