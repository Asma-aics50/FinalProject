using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class AllDrugViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double? Cost { get; set; }
        public string CompanyName { get; set; }
    }
}