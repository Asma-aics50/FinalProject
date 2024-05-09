using FinalProject.Data.Enum;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.ViewModels;
using FinalProject.ViewModels.Appointment;
using FinalProject.ViewModels.PatientHistory;
using FinalProject.ViewModels.Prescreption;
using System.Numerics;

namespace FinalProject.Services
{
    public static class MapRepositry
    {

        static public AllDoctorsViewModel MapToAllDoctorVM(Doctor doctor)
        {
            return new AllDoctorsViewModel
            {
                Department = doctor.Department.Name,
                Name = $"{doctor.User.FirstName} {doctor.User.LastName}",
                PhoneNumber = doctor.User.PhoneNumber,
                Email = doctor.User.Email,
                ShiftStartTime = doctor.ShiftStartTime,
                ShiftEndTime = doctor.ShiftEndTime,
                Id = doctor.Id
            };
        }

        public static AllPatientViewModel MapToAllPatientsVM(Patient patient)
        {
            return new AllPatientViewModel
            {
                Id = patient.Id,
                Name = $"{patient.User.FirstName} {patient.User.LastName}",
                PhoneNumber = patient.User.PhoneNumber,
                Email = patient.User.Email,


            };
        }
        public static AllPatientsAppointmentViewModel MapToAllPatientsAppointmentVM(BookedAppointment appointment)
        {
            return new AllPatientsAppointmentViewModel
            {
               Id=appointment.Id,
               DoctorName = $"{appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName}",
               PatientName = $"{appointment.Patient.User.FirstName} {appointment.Patient.User.LastName}",
               DateTime=appointment.DateTime,
               AppointmentStatus = (AppointmentStatues)appointment.AppointmentStatues,

            };
        }
        public static ForDoctorsListViewModel MapToCreateAppointmentDoctors(Doctor doctor)
        {
            return new ForDoctorsListViewModel
            {
               Id=doctor.Id,
               Name = $"{doctor.User.FirstName} {doctor.User.LastName}",
              
            };
        } 
        public static ForPatientsListViewModel MapToCreateAppointmentPatients(Patient patient)
        {
            return new ForPatientsListViewModel
            {
               Id=patient.Id,
               Name = $"{patient.User.FirstName} {patient.User.LastName}",
              
            };
        } 
        public static BookedAppointment MapToBookedAppointment(CreateEditAppointmentViewModel appointmentVM)
        {
            return new BookedAppointment
            {
                Id=appointmentVM.Id,
                DoctorId=appointmentVM.DoctorId,
                PatientId=appointmentVM.PatientId,
                DateTime=appointmentVM.DateTime,
                AppointmentStatues=appointmentVM.AppointmentStatues              
            };
        }
        public static BookedAppointment MapToAutoBookedAppointment(CreateViewModel prescreptionVM)
        {
            return new BookedAppointment
            {

                DoctorId = prescreptionVM.DoctorId,
                PatientId = prescreptionVM.PatientId,
                DateTime = (DateTime)prescreptionVM.ReExaminatoinDate,
                AppointmentStatues = AppointmentStatues.confirmed,

            };
        }




    
        
        public static CreateEditAppointmentViewModel MapToCreateEditAppointmentVM(BookedAppointment appointment)
        {
            return new CreateEditAppointmentViewModel
            {
                Id=appointment.Id,
                DoctorId=appointment.DoctorId,
                PatientId=appointment.PatientId,
                DateTime=appointment.DateTime,
                AppointmentStatues=appointment.AppointmentStatues              
            };
        }
        public static PatientHistory MapToPatientHistory(CreateViewModel PatienthistoryVM)
        {
            return new PatientHistory()
                      {
                          PatientId = PatienthistoryVM.PatientId,
                          Problem = PatienthistoryVM.Problem,
                          ReExaminatoinDate = PatienthistoryVM.ReExaminatoinDate,
                          Height = PatienthistoryVM.Height,
                          Weight = PatienthistoryVM.Weight,
                          BloodPressure = PatienthistoryVM.BloodPressure,
                          Note = PatienthistoryVM.Note,
                          CreatedAt = DateTime.Now,
                          DoctorId = PatienthistoryVM.DoctorId
                      };

        }
        public static PatientHistoryViewModel MapToPatientHistoryVM(PatientHistory patienthistory)
        {
            return new PatientHistoryViewModel()
             {
                Id=patienthistory.Id,
                Problem=patienthistory.Problem,
                DoctorId=patienthistory.DoctorId,
                PatientId=patienthistory.PatientId,
                PatientEmail=patienthistory.Patient.User.Email,
                PatientName=$"{patienthistory.Patient.User.FirstName} {patienthistory.Patient.User.LastName}",
             };

        }
    }
}
