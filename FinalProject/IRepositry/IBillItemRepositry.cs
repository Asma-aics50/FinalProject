using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IBillItemRepositry
    {
        public void Cearte(BillItems billitem);
        public void Delete(int bill_id, int servise_id);
        public BillItems Get(int bill_id ,int servise_id);
   
        public List<BillItems> GetAll();
        public void Update(BillItems billitem);
       
    }
}
