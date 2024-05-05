using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IDrugRepositry
    {
        public void Create(Drug drug);
        public void Update(Drug drug);
        public void Delete(int id);
        public Drug GetById(int id);
        public List<Drug> GetAll();
    }
}
