namespace FinalProject.Models
{
    public class PatientHistoryMedicalAnalysis
    {
        public int PatientHistoryId { get; set; }
        public int MedicalAnaylsisId { get; set; }
        public DateTime DateTime { get; set; }
        public string Result {  get; set; }

        public PatientHistory PatientHistory { get; set; }
        public MedicalAnaylsis MedicalAnaylsis { get; set; }
    }
}
