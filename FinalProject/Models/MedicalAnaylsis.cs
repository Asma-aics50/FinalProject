namespace FinalProject.Models
{
    public class MedicalAnaylsis
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientHistoryMedicalAnalysis> PatientHistoryMedicalAnalyses { get; set; }

    }
}
