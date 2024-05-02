using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IEmployeeRepositry
    {
        public void Create(Employee employee);
        public void Update(Employee employee);
        public Employee GetById(int id);
        public List<Employee> GetAll();
        public void Delete(int id);

    }
}
