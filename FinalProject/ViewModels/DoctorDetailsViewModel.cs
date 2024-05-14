using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class DoctorDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ShiftStartTime { get; set;}
        public int ShiftEndTime { get; set;}
        public string Address { get; set;}
        public string Gender { get; set;}
        public string Specialist { get; set; }
        public string BloodGroup { get; set;}
        public DateOnly BirthDate { get; set;}
        public double Salary { get; set;}
        public int DepartmentId { get; set; }
        public string Department { get; set; }

    }
}
