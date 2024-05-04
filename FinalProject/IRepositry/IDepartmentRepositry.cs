using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IDepartmentRepositry
    {
        public void Create(Department department);
        public void Update(Department department);
        public Department GetById(int id);
        public List<Department> GetAll();
        public void Delete(int id);

    }
}
