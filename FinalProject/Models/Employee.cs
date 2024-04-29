namespace FinalProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public string Specialization { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }    
        public User User { get; set; }  

    }
}
