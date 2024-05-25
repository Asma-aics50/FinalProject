using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.IRepositry
{
    public interface ICompanyRepositry
    {
        public void Create(Company company);
        public void Update(Company company);   
        public Company GetById(int id);
        public List<Company> GetAll();
        public void Delete(int id);
        public void UpdateEditCompany(EditCompanyViewModel editCompanyView);
    }
}
