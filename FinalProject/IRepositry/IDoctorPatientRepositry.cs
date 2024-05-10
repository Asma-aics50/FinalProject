using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IDoctorPatientRepositry
    {
        public void Create(DoctorPatient doctorPatient);
        public DoctorPatient FindById(DoctorPatient doctorPatient);


    }
}
