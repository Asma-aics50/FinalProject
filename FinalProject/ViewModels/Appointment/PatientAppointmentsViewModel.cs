using FinalProject.Data.Enum;

namespace FinalProject.ViewModels.Appointment
{
    public class PatientAppointmentsViewModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        
        public DateTime DateTime { get; set; }
        public AppointmentStatues AppointmentStatus { get; set; }
    }
}
