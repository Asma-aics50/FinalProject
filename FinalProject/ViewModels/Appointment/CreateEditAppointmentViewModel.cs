using FinalProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels.Appointment
{
    public class CreateEditAppointmentViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="Doctor")]
        public int DoctorId { get; set; }

        [Required]

        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required]

        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [Required]

        [Display(Name = "Appointment Status")]
        public AppointmentStatues AppointmentStatues { get; set; }
    }
}
