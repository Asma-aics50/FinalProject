using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class EmployeeRepositry : IEmployeeRepositry
    {
        HospitalManagementSystemDbContext context;

        public EmployeeRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();

        }


        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }

        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }


        public Employee GetById(int id)
        {
            return context.Employees.Find(id);

        }

        public void Update(Employee _employee)
        {
            var employee = GetById(_employee.Id);
            if (employee != null)
            {
                employee.Salary = _employee.Salary;
                employee.Specialization=_employee.Specialization;
                employee.DeptId= _employee.DeptId;
               
                context.SaveChanges();
                
            }


        }

    }
}
