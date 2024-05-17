using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class EditPatientViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        
    }
}
