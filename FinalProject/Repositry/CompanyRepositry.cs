using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Repositry
{
    public class CompanyRepositry : ICompanyRepositry
    {
        HospitalManagementSystemDbContext context;
        public CompanyRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Company company)
        {
            context.Companys.Add(company);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = GetById(id);  
            if (company != null )
            {
                context.Companys.Remove(company);
                context.SaveChanges();
            }
        }

        public List<Company> GetAll()
        {
            return context.Companys.ToList();
        }

        public Company GetById(int id)
        {
            return context.Companys.Find(id);

        }

        public void Update(Company _company)
        {
            var company = GetById(_company.Id);
            if (company != null)
            {
                company.Name = _company.Name;
                company.Street = _company.Street;
                company.City = _company.City;
                company.Specialization = _company.Specialization;
                company.ZipCode = _company.ZipCode;
                context.SaveChanges();
            }
        }
        public void UpdateEditCompany(EditCompanyViewModel editCompanyView)
        {
            var company = GetById(editCompanyView.Id);
            if (company != null)
            {
                company.Name = editCompanyView.Name;
                company.Street = editCompanyView.Street;
                company.City = editCompanyView.City;
                company.Specialization = editCompanyView.Specialization;
                company.ZipCode = editCompanyView.ZipCode;
                context.SaveChanges();
            }
        }
    }
}
