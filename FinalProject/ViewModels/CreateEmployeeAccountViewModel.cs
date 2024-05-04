using FinalProject.Data.Enum;
using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateEmployeeAccountViewModel
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
        public DateOnly BirthDate { get; set; }

        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        public string Specialization { get; set; }
        [Display(Name ="Department")]
        public int DeptId { get; set; }

        public double Salary { get; set; }

    }
}
