using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositry
{
    public class PatientRepositry : IPatientRepositry
    {
        HospitalManagementSystemDbContext context;

        public PatientRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }



        public void Create(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var patient = GetById(id);
           if(patient != null )
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
        }

        public List<Patient> GetAll()
        {
            return context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return context.Patients.Find(id);
        }
        public Patient _GetByIdUser(int id)
        {
            return context.Patients.Include(e=>e.User).Where(e => e.Id == id).FirstOrDefault();
        }

        public void Update(Patient _patient)
        {
            var patient = GetById(_patient.Id);
            if(patient != null)
            {
                patient.BloodGroup = _patient.BloodGroup;
                context.SaveChanges();
               
            }
        }

        public void UpdateUserPatient(EditPatientViewModel patientDetails)
        {
            var patients = _GetByIdUser(patientDetails.Id);
            if(patients != null)
            {
                patients.User.FirstName = patientDetails.FirstName;
                patients.User.LastName = patientDetails.LastName;
                
                patients.User.Gender = patientDetails.Gender;
                patients.User.BirthDate = patientDetails.BirthDate;
                patients.User.PhoneNumber = patientDetails.PhoneNumber;
                context.SaveChanges();
            }
        }
        
        public List<Patient> GetAll_Patients_User()
        {
            return context.Patients.Include(e=>e.User).ToList();
        }
    }
}
