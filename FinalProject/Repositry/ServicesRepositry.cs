using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Repositry
{
    public class ServicesRepositry :IServiceRepositry
    {
        HospitalManagementSystemDbContext context;
        public ServicesRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
           var servise = GetById(id);
            if (servise != null)
            {
                context.Services.Remove(servise);
                context.SaveChanges();
            }
        }

        public List<Service> GetAll()
        {
            return context.Services.ToList();   
        }

        public Service GetById(int id)
        {
            return context.Services.Find(id);
        }
        public Service GetByName(string name)
        {
            return context.Services.FirstOrDefault(m => m.Name == name);
        }


        public void Update(Service _service)
        {
            var service = GetById(_service.Id);
            if (service != null)
            {
                service.Price = _service.Price;
                service.Name = _service.Name;

                context.SaveChanges();
            }
        }
        public void UpdateEditServices(EditServicesViewModel editServicesView)
        {
            var service = GetById(editServicesView.Id);
            if (service != null)
            {
                service.Price = editServicesView.Price;
                service.Name = editServicesView.Name;

                context.SaveChanges();
            }
        }
    }
}
