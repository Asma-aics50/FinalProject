using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class PatientHistory
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<PatientHistoryMedicalAnalysis> PatientHistoryMedicalAnalyses { get; set; }   
        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
