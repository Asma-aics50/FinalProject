using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class BillItemRepository : IBillItemRepositry
    {
        HospitalManagementSystemDbContext context;
        public BillItemRepository(HospitalManagementSystemDbContext context) 
        { 
            this.context = context;
        }
       

        public void Cearte(BillItems billitem)
        {
            context.Add(billitem);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var billitem = Get(id);
            if (billitem != null) 
            { 
                context.Remove(billitem);
                context.SaveChanges();
            }
           
        }

        public BillItems Get(int id)
        {
            return context.BillItems.Find(id);
        }

        public void Update(BillItems _billitem)
        {
            var billitems = Get(_billitem.id);
        }

        List<BillItems> IBillItemRepositry.GetAll()
        {
           return context.BillItems.ToList();
        }

        
    }
}
