using FinalProject.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }

       






    }
}
