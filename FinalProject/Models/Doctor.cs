using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Specialization { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public string Medical_License_no { get; set;}
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int DeprtId { get; set; }
        public Department Department { get; set; }
        List<Patient> patients { get; set; }
        List<PatientHistory> PatientHistories { get; set; }



    }
}
