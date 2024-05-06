using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
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

        public void Update(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAll_Patients_User()
        {
            return context.Patients.Include(e=>e.User).ToList();
        }
    }
}
