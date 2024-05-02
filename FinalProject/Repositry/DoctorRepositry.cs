using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class DoctorRepositry : IDoctorRepositry
    {
        HospitalManagementSystemDbContext context;

        public DoctorRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChanges();

        }


       public void Delete(int id)
        {
            var doctor = GetById(id);
            if(doctor  != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }

        }

        public List<Doctor>  GetAll()
        {
            return context.Doctors.ToList();
        }


        public Doctor GetById(int id)
        {
            return context.Doctors.Find(id);
           
        }

        public void Update(Doctor _doctor)
        {
            var doctor = GetById(_doctor.Id);
            if(doctor != null )
            {
                doctor.DeprtId = _doctor.DeprtId;
                doctor.EndDate = _doctor.EndDate;
                doctor.StartDate=_doctor.StartDate;
                context.SaveChanges();
            }


        }
    }
}
