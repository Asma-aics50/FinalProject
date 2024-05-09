using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels.Prescreption
{
    public class CreateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Chief Complaint * ")]
        public string Problem { get; set; }
        

        public DateTime CreatedAt { get; set; }
        [Display(Name = "Re Examinatoin Date")]
        public DateTime? ReExaminatoinDate { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        [Display(Name ="Blood Pressure")]
        public string?BloodPressure { get; set; }
        [Display(Name ="Notes")]
        public string? Note { get; set; }

        [Display (Name ="Patient Name")]
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
       



    }
}
