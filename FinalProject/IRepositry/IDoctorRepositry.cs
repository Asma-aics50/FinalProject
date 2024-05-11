using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IDoctorRepositry
    {

        public void Create(Doctor doctor);
        public void Update(Doctor doctor);
        public Doctor GetById(int id);
        public List<Doctor> GetAll();
        public void Delete(int id);


        public List<Doctor> GetAll_Departments_User();

        public List<Doctor> GetAll_User();


        public Doctor FindByUserId(string id);

    }
}
