using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Migrations;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class PrescriptionRepository : IPrescriptionRepositry
    {
        HospitalManagementSystemDbContext context;
        public PrescriptionRepository(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(Prescription prescription)
        {
            context.Add(prescription);
            context.SaveChanges();
        }

        public void Delete(int patient_id, int drug_id)
        {
            var pres = GetById(patient_id,drug_id);
            if (pres != null)
            {
                context.Remove(pres);
                context.SaveChanges();
            }
        }

        public List<Prescription> GetAll()
        {
            return context.Prescriptions.ToList();
        }

        public Prescription GetById(int patient_id, int drug_id)
        {
            return context.Set<Prescription>().SingleOrDefault(e => e.DrugId== drug_id && e.PatientHistoryId == patient_id);
        }

        public void Update(Prescription prescription)
        {
            var pres = GetById (prescription.PatientHistoryId,prescription.DrugId);
            if (pres != null)
            {
                pres.NoOfTimes= prescription.NoOfTimes;
                pres.Duration = prescription.Duration;  
                pres.Quantity = prescription.Quantity;  
                pres.DrugId = prescription.DrugId;  
                pres.PatientHistoryId = prescription.PatientHistoryId;
                context.SaveChanges();
            }
        }
    }
}
