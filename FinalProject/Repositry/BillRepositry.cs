using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class BillRepositry : IBillRepositry
    {
        HospitalManagementSystemDbContext context;
        public BillRepositry(HospitalManagementSystemDbContext context)
        { 
            this.context = context;
        }
        public void Create(Bill bill)
        {
            context.Add(bill);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var bill = GetById(id);
            if (bill != null) 
            { 
                context.Remove(bill);
                context.SaveChanges();
            }
        }

        public List<Bill> GetAll()
        {
            return context.Bills.ToList();
        }

        public Bill GetById(int id)
        {
            return context.Bills.Find(id);
        }

        public void Update(Bill _bill)
        {
            var bill = GetById(_bill.Id);
            if (bill != null)
            {
                bill.Total = _bill.Total;
                bill.Date = _bill.Date; 
                bill.PatientId = _bill.PatientId;
                context.SaveChanges();
            }

        }
    }
}
