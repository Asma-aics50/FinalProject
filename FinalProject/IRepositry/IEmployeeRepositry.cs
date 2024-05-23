using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.IRepositry
{
    public interface IEmployeeRepositry
    {
        public void Create(Employee employee);
        public void Update(Employee employee);
        public Employee GetById(int id);
        public List<Employee> GetAll();
        public void Delete(int id);
        public List<Employee> GetAll_Departments_User();
        public Employee _GetByIdUser(int id);

        public void UpdateeEiteEmployee(EditEmployeeViewModel editEmployeeView);
    }
}
