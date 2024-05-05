using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class PatientHistoryRepositry : IPatientHistoryRepositry
    {
        HospitalManagementSystemDbContext context;
        public PatientHistoryRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public PatientHistory Get(int id)
        {
            return context.PatientHistories.Find(id);
        }

        void IPatientHistoryRepositry.Create(PatientHistory patientHistory)
        {
            context.Add(patientHistory);
            context.SaveChanges();
        }

        void IPatientHistoryRepositry.Delete(int id)
        {
            var patient = Get(id);
            if (patient != null) 
            { 
                context.Remove(patient);
                context.SaveChanges();
            }
        }

        List<PatientHistory> IPatientHistoryRepositry.GetAll()
        {
            return context.PatientHistories.ToList();
        }

       
        void IPatientHistoryRepositry.Update(PatientHistory _patientHistory)
        {
            var patienthistory = Get(_patientHistory.Id);
            if(patienthistory != null)
            {
                patienthistory.Problem = _patientHistory.Problem;
                patienthistory.DateTime = _patientHistory.DateTime;
                patienthistory.DoctorId = _patientHistory.DoctorId;
                patienthistory.PatientId = _patientHistory.PatientId;
                context.SaveChanges();
            }
        }
    }
}
