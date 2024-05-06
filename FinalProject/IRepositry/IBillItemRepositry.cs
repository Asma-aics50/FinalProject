using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IBillItemRepositry
    {
        public void Cearte(BillItems billitem);
        public void Delete(int id);
        public BillItems Get(int id);
   
        public List<BillItems> GetAll();
        public void Update(BillItems billitem);
       
    }
}
