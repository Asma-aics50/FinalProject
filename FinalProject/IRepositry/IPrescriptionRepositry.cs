using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IPrescriptionRepositry
    {
        public void Create(Prescription prescription);
        public void Update(Prescription prescription);
        public void Delete(int patient_id, int drug_id);
        //public Prescription GetById(Prescription prescription);
        public Prescription GetById(int patient_id , int drug_id);
        public List<Prescription> GetAll();

        public List<Prescription> GetAll_DrugByPatientHistoryId(int patientHistoyId);

    }
}
