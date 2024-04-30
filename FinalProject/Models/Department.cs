using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Doctor> Doctors  { get; set; }
    }
}
