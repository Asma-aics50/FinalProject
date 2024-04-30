using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Drug
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string Description { get; set; }
        [Required]
        public double? Cost { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
