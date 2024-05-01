using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateRoleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
