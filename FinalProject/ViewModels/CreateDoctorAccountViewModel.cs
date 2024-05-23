using FinalProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateDoctorAccountViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? Email { get; set; }
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Password Confirm")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]

        [Display(Name = "BirthDate")]
        public DateOnly BirthDate { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
       
        [Required]
        public string Specialization { get; set; }
       
        [Display(Name = "Department")]
        public int DeptId { get; set; }

        public double Salary { get; set; }

        [Display(Name = "Shift Start Time")]
        public int ShiftStartTime { get; set; }

        [Display(Name = "Shift End Time")]
        public int ShiftEndTime { get; set; }
        [Display(Name = "Medical License Number")]
        public string Medical_License_no { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
