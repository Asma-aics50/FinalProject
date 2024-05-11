using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repositry
{
    public class BookedAppointmentRepositry : IBookedAppointmentsRepositry
    {
        HospitalManagementSystemDbContext context;
        public BookedAppointmentRepositry(HospitalManagementSystemDbContext context)
        {
            this.context = context;
        }
        public void Create(BookedAppointment bookedAppointment)
        {
            context.BookedAppointments.Add(bookedAppointment);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                context.Remove(book);
                context.SaveChanges();
            }
        }

        public List<BookedAppointment> GetAll()
        {
            return context.BookedAppointments.ToList();

        }
        public BookedAppointment GetById(int id)
        {
            return context.BookedAppointments.Find(id);
        }

        public void Update(BookedAppointment _bookedAppointment)
        {
            var books = GetById(_bookedAppointment.Id);
            if (books != null) 
            {
                books.AppointmentStatues = _bookedAppointment.AppointmentStatues;
                books.DateTime = _bookedAppointment.DateTime;
                books.PatientId = _bookedAppointment.PatientId;
                books.DoctorId = _bookedAppointment.DoctorId;
                context.SaveChanges();
            }
        }
        public List<BookedAppointment> GetAllAppointments_Patient_Doctor()
        {
            return context.BookedAppointments.Include(e=>e.Doctor.User).Include(e=>e.Patient.User).ToList();

        }
        public List<BookedAppointment> GetAllAppointmentsByDoctorId_Patient_Doctor(int doctorid)
        {
            return context.BookedAppointments.Include(e=>e.Doctor.User).Include(e=>e.Patient.User).Where(e=>e.DoctorId==doctorid).ToList();

        }

       BookedAppointment IBookedAppointmentsRepositry.GetOne_Doctor_Patient(int id)
        {
            return context.BookedAppointments.Include(e => e.Patient).Include(e => e.Doctor).Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
