using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels.Prescreption
{
    public class PrescreptionDetailsViewModel
    {
        public int Id { get; set; }
        //Patient
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        //CaseStudy

        public int PatientHistoryId { get; set; }
        public string Problem { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ReExaminatoinDate { get; set; }
        
        public double? Weight { get; set; }
        public double? Height { get; set; }
        
        public string? BloodPressure { get; set; }
        public string? Note { get; set; }


        

        
    }
}
