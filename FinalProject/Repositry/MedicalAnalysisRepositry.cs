using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;

namespace FinalProject.Repositry
{
    public class MedicalAnalysisRepositry : IMedicalAnalysisRepositry
    {
        HospitalManagementSystemDbContext context;
        public MedicalAnalysisRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }

        public void Create(MedicalAnaylsis medicalAnaylsis)
        {
            context.Add(medicalAnaylsis);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var medical = GetById(id);
            if (medical != null) 
            { 
                context.Remove(medical);
                context.SaveChanges();
            }
        }

        public List<MedicalAnaylsis> GetAll()
        {
            return context.MedicalAnaylses.ToList();
        }

        public MedicalAnaylsis GetById(int id)
        {
            return context.MedicalAnaylses.Find(id);
        }

        public void Update(MedicalAnaylsis _medicalAnaylsis)
        {
            var medical = GetById(_medicalAnaylsis.Id);
            if (medical != null) 
            {
                medical.Name = _medicalAnaylsis.Name;
                context.SaveChanges();

            }
        }
    }
}
