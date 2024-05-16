using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class PatientDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public string Gender { get; set;}
        public string PhoneNumber { get; set;}
        public DateOnly BirthDate { get; set;}
        public ApplicationUser User { get; set; }

    }
}
