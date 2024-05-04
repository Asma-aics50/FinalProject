using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Specialization { get; set; }
        public double Salary { get; set; }
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; } 
        public string Medical_License_no { get; set;}
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        List<Patient>? Patients { get; set; }
        List<PatientHistory>? PatientHistories { get; set; }



    }
}
