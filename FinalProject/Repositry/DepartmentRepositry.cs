using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Repositry
{
    public class DepartmentRepositry : IDepartmentRepositry
    {
        HospitalManagementSystemDbContext context;
        public DepartmentRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Department department)
        {
           context.Add(department);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = GetById(id);
            if(dept != null) 
            { 
                context.Remove(dept);
                context.SaveChanges();
            }
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        }

        public void Update(Department _department)
        {
            var dept = GetById(_department.Id);
            if(dept != null)
            {
                dept.Name = _department.Name;
                context.SaveChanges();
            }
        }
        public void UpdateEditDept(EditDepartmentViewModel editDepartmentViewModel)
        {
            var dept = GetById(editDepartmentViewModel.Id);
            if (dept != null)
            {
                dept.Name = editDepartmentViewModel.Name;
                context.SaveChanges();
            }
        }
    }
}
