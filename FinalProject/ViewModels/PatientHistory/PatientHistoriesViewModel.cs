namespace FinalProject.ViewModels.PatientHistory
{
    public class PatientHistoriesViewModel
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public string DoctorName { get; set; }
        public string DoctorSpecialization { get; set; }

    }
}
