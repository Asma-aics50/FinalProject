using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class AllEmployeesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
       
        public string Specialization { get; set; }
       
        public string Department { get; set; }
       

    }
}
