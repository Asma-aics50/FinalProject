using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        [Required]
        public string Specialization { get; set; }
    }
}
