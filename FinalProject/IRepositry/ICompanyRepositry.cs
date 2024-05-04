using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface ICompanyRepositry
    {
        public void Create(Company company);
        public void Update(Company company);   
        public Company GetById(int id);
        public List<Company> GetAll();
        public void Delete(int id);
    }
}
