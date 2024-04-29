namespace FinalProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<PatientHistory> PatientHistory { get; set; }
        public List<Bill> Bills { get; set; }   

    }
}
