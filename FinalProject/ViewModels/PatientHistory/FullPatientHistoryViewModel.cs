namespace FinalProject.ViewModels.PatientHistory
{
    public class FullPatientHistoryViewModel
    {
        public string Problem { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        //Patient
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}
