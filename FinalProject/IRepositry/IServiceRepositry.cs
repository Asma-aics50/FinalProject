using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.IRepositry
{
    public interface IServiceRepositry
    {
        public void Create(Service service);
        public void Update(Service service);
        public void Delete(int id);
        public Service GetById(int id);
        public List<Service> GetAll();
        public void UpdateEditServices(EditServicesViewModel editServicesView);
        public Service GetByName(string name);
    }
}
