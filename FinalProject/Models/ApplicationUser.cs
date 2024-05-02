using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Gender { get; set;}
        public DateOnly BirthDate { get; set;}
        

    }
}
