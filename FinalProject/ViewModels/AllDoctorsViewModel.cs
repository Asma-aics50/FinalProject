using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class AllDoctorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; }
        public string Department { get; set; }



    }
}
