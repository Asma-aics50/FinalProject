namespace FinalProject.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string Speciatization { get; set; }
        public DateOnly BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }


    }
}
