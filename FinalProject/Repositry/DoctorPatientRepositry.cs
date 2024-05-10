using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class DoctorPatientRepositry : IDoctorPatientRepositry
    {
        HospitalManagementSystemDbContext context;
        public DoctorPatientRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }
      
        public void Create(DoctorPatient doctorPatient)
        {
            DoctorPatient  check= FindById(doctorPatient);
            if(check==null)
            {
                context.DoctorPatients.Add(doctorPatient);
                context.SaveChanges();

            }
        }

        public DoctorPatient FindById(DoctorPatient doctorPatient)
        {
            return context.DoctorPatients.Where(e => e.PatientId == doctorPatient.PatientId && e.DoctorId == doctorPatient.DoctorId).FirstOrDefault();
        }
    }
}
