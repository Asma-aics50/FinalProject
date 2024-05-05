using FinalProject.Models;

namespace FinalProject.IRepositry
{
    public interface IBookedAppointmentsRepositry
    {
        public void Create(BookedAppointment bookedAppointment);
        public void Update(BookedAppointment bookedAppointment);
        public void Delete(int id);
        public BookedAppointment GetById(int id);
        public List<BookedAppointment> GetAll();

    }
}
