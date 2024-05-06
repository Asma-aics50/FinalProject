using FinalProject.Models;
using FinalProject.ViewModels;
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
    }
}
