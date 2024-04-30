namespace FinalProject.Models
{
    public class Prescription
    {
        public int PatientHistoryId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
        public int NoOfTimes { get; set; }
        public string Duration { get; set; }

        public PatientHistory PatientHistory { get; set; }
        public Drug Drug { get; set; }
    }
}
