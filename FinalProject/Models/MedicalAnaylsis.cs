using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class MedicalAnaylsis
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<PatientHistoryMedicalAnalysis> PatientHistoryMedicalAnalyses { get; set; }

    }
}
