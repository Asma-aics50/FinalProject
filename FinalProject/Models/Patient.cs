using FinalProject.Data.Enum;

namespace FinalProject.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        //public List<Doctor> Doctors { get; set; }
        
       
        public List<DoctorPatient> DoctorPatients { get; set; }
        public List<PatientHistory> PatientHistory { get; set; }
        public List<BookedAppointment> BookedAppointments { get; set; }

        
        public List<Bill> Bills { get; set; }  
        

    }
}
