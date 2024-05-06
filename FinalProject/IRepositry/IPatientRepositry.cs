using FinalProject.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace FinalProject.IRepositry
{
    public interface IPatientRepositry
    {

        public void Create(Patient patient);
        public void Update(Patient patient);
        public Patient GetById(int id);
        public List<Patient> GetAll();
        public void Delete(int id);
        public List<Patient> GetAll_Patients_User();
    }
}
