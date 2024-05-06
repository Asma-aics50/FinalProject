using FinalProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class BookedAppointment
    {

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId {  get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        public AppointmentStatues AppointmentStatues { get; set; }
    
    }

}
