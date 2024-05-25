using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.ViewModels;
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
        public void UpdateEditDrug(EditDrugViewModel editDrugView)
        {
            var drug = GetById(editDrugView.Id);
            if (drug != null)
            {
                drug.Cost = editDrugView.Cost;
                drug.Name = editDrugView.Name;
                drug.Description = editDrugView.Description;
                drug.CompanyId = editDrugView.CompanyId;

                context.SaveChanges();
            }
        }
        public Drug _GetByIdUser(int id)
        {
            return context.Drugs.Include(e => e.Company).Where(e => e.Id == id).FirstOrDefault();

        }
    }
}
