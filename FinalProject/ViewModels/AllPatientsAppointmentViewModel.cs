using FinalProject.Data.Enum;

namespace FinalProject.ViewModels
{
    public class AllPatientsAppointmentViewModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string PatientName{ get; set; }
      
        public DateTime DateTime { get; set; }
        public AppointmentStatues AppointmentStatus { get; set; }
    }
}
