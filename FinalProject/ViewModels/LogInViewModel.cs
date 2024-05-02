using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class LogInViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
