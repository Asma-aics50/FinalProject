namespace FinalProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public string Medical_License_no{ get; set;}
        public int UserId { get; set; }
        public User User { get; set; }
        public int DeprtId { get; set; }
        public Department Department { get; set; }
        List<Patient> patients { get; set; }
        List<PatientHistory> PatientHistories { get; set; }



    }
}
