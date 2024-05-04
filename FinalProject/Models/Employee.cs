using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        [Required]
        public string Specialization { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string UserId { get; set; }    
        public ApplicationUser User { get; set; }  

    }
}
