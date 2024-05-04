using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IBillRepositry
    {
        public void Create(Bill bill);
        public void Update(Bill bill); 
        public Bill GetById(int id);
        public List<Bill> GetAll();
        public void Delete(int id);
    }
}
