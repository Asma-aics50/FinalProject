using FinalProject.Models;

namespace FinalProject.ViewModels.PatientHistory
{
    public class PatientHistoryViewModel
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public DateTime CreatedAt { get; set; }

        public int DoctorId { get; set; }

    }
}
