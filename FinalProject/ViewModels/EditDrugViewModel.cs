using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class EditDrugViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Cost { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }

    }
}
