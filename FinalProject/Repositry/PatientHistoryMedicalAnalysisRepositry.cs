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

        public void Delete(int id)
        {
            var phma = GetById(id);
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

        public PatientHistoryMedicalAnalysis GetById(int id)
        {
            return context.PatientHistoryMedicalAnalyses.Find(id);
        }

        public void Update(PatientHistoryMedicalAnalysis _patientHistoryMedicalAnalysis)
        {
            //var phma = GetById(_patientHistoryMedicalAnalysis.id);
        }
    }
}
