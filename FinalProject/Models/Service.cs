using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public ICollection<BillItems> BillItems { get; set; }
    }
}
