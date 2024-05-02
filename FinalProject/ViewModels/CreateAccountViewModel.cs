using FinalProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateAccountViewModel
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
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Phone]
        public string  Phone { get; set; }
        [Required]
        public string  Role { get; set; }




    }
}
