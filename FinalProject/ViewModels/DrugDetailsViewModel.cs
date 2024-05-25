using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class DrugDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double? Cost { get; set; }
       
       
        public int CompanyId { get; set;}
        public string Company { get; set; }
    }
}
