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

        public void Delete(int bill_id, int servise_id)
        {
            var billitem = Get( bill_id,  servise_id);
            if (billitem != null) 
            { 
                context.Remove(billitem);
                context.SaveChanges();
            }
           
        }

        public BillItems Get(int bill_id, int servise_id)
        {
            return context.Set<BillItems>().SingleOrDefault(x=>x.BillId== bill_id&& x.ServiceId==servise_id);
        }

        public void Update(BillItems _billitem)
        {
            var billitems = Get(_billitem.BillId,_billitem.ServiceId);
            if (billitems != null)
            { 
                billitems.ServiceId = _billitem.ServiceId;  
                billitems.BillId = _billitem.BillId;
            }
        }

        List<BillItems> IBillItemRepositry.GetAll()
        {
           return context.BillItems.ToList();
        }

        
    }
}
