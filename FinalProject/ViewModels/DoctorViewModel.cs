using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewModels
{
    public class DoctorViewModel 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
