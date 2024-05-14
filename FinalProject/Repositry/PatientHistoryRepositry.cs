using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

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

        PatientHistory IPatientHistoryRepositry.FindByPatientIdAndDate(DateTime createdAt, int patientId)
        {
            return context.PatientHistories.FirstOrDefault(e=>e.CreatedAt==createdAt && e.PatientId==patientId);
         }
       List< PatientHistory >IPatientHistoryRepositry.FindePatinetByDoctor(int doctorId)
        {

            return context.PatientHistories.Include(e=>e.Patient).Include(e=>e.Patient.User).Where(e => e.DoctorId == doctorId).ToList();
        
        }
         public  PatientHistory Find_Patinet_UsrById(int id)
        {

            return context.PatientHistories.Include(e => e.Patient).Include(e => e.Patient.User).FirstOrDefault(e => e.Id == id);
        
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
                patienthistory.Height = _patientHistory.Height;
                patienthistory.Weight = _patientHistory.Weight;
               
                patienthistory.Note = _patientHistory.Note;
                patienthistory.ReExaminatoinDate = _patientHistory.ReExaminatoinDate;
                patienthistory.BloodPressure = _patientHistory.BloodPressure;

                patienthistory.DoctorId = _patientHistory.DoctorId;
                patienthistory.PatientId = _patientHistory.PatientId;
                context.SaveChanges();
            }
        }
    }
}
