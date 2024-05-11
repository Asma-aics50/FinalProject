using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Migrations;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

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

            Prescription check = GetById(prescription.PatientHistoryId, prescription.DrugId);
            if (check == null)
            {
                context.Add(prescription);
                context.SaveChanges();
            }
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
        public List<Prescription> GetAll_DrugByPatientHistoryId(int patientHistoyId)
        {
            return context.Prescriptions.Include(e=>e.Drug).Where(e=>e.PatientHistoryId==patientHistoyId).ToList();
        }

        public Prescription GetById(int patient_id, int drug_id)
        {
            return context.Set<Prescription>().SingleOrDefault(e => e.DrugId== drug_id && e.PatientHistoryId == patient_id);
        }

        public void Update(Prescription prescription)
        {
        //    var pres = GetById (prescription.PatientHistoryId,prescription.DrugId);
        //    if (pres != null)
        //    {
        //        pres.
        //    }
        //
        }
    }
}
