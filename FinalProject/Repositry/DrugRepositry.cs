using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositry
{
    public class DrugRepositry : IDrugRepositry
    {
        HospitalManagementSystemDbContext context;
        public DrugRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Drug drug)
        {
            context.Add(drug);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var drug = GetById(id);
            if (drug != null)
            {
                context.Remove(drug);
                context.SaveChanges();
            }
        }

        public List<Drug> GetAll()
        {
            return context.Drugs.Include(x=>x.Company).ToList();
        }

        public Drug GetById(int id)
        {
            return context.Drugs.Find(id);
        }

        public void Update(Drug _drug)
        {
            var drug = GetById(_drug.Id);
            if (drug != null) 
            { 
                drug.Cost = _drug.Cost;
                drug.Name = _drug.Name;
                drug.Description = _drug.Description;
                drug.CompanyId = _drug.CompanyId;
                context.SaveChanges();
            }
        }
    }
}
