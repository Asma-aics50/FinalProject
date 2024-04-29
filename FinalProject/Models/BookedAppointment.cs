using FinalProject.Data.Enum;

namespace FinalProject.Models
{
    public class BookedAppointment
    {
        public int DoctorId { get; set; }
        public int PatientId {  get; set; }

        public DateTime DateTime { get; set; }
        public AppointmentStatues AppointmentStatues { get; set; }
    }
}
