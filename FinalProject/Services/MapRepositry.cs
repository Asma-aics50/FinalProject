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
        static public AllDrugViewModel MapRoAllDrugVM(Drug drug) 
        {
            return new AllDrugViewModel 
            { 
                Id = drug.Id,
                Name = drug.Name,
                Cost = drug.Cost,
                CompanyName =drug.Company.Name
            };
        }
        static public AllEmployeesViewModel MapToAllEmployeeVM(Employee employee) 
        {
            return new AllEmployeesViewModel
            {
                Department = employee.Department.Name,
                Name = $"{employee.User.FirstName} {employee.User.LastName}",
                Email = employee.User.Email,
                PhoneNumber = employee.User.PhoneNumber,
                Salary = employee.Salary,
                Specialization = employee.Specialization,
                Id= employee.Id
            };
        }
        static public AllServicesViewModel MapToAllServicesVM(Service service) 
        {
            return new AllServicesViewModel
            {
                Id = service.Id,
                Name = service.Name,    
                Price = service.Price
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
        public static AllPatientViewModel MapToAllPatientsVM(DoctorPatient doctorPatient)
        {
            return new AllPatientViewModel
            {
                Id = doctorPatient.Patient.Id,
                Name = $"{doctorPatient.Patient.User.FirstName} {doctorPatient.Patient.User.LastName}",
                PhoneNumber = doctorPatient.Patient.User.PhoneNumber,
                Email = doctorPatient.Patient.User.Email,


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
        public static CreateViewModel MapToCreateVM(PatientHistory Patienthistory)
        {
            return new CreateViewModel()
                      {
                          Id=Patienthistory.Id,
                          PatientId = Patienthistory.PatientId,
                          Problem = Patienthistory.Problem,
                          ReExaminatoinDate = Patienthistory.ReExaminatoinDate,
                          Height = Patienthistory.Height,
                          Weight = Patienthistory.Weight,
                          BloodPressure = Patienthistory.BloodPressure,
                          Note = Patienthistory.Note,
                          CreatedAt = Patienthistory.CreatedAt,
                          DoctorId = Patienthistory.DoctorId

                      };

        }
        public static PatientHistory MapToEditPatientHistory(CreateViewModel createPrVM)
        {
            return new PatientHistory()
                      {
                          Id= createPrVM.Id,
                          PatientId = createPrVM.PatientId,
                          Problem = createPrVM.Problem,
                        
                ReExaminatoinDate = createPrVM.ReExaminatoinDate,
                          Height = createPrVM.Height,
                          Weight = createPrVM.Weight,
                
                BloodPressure = createPrVM.BloodPressure,
                          Note = createPrVM.Note,
                          DoctorId = createPrVM.DoctorId,
                          
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
                CreatedAt = patienthistory.CreatedAt,
                PatientName=$"{patienthistory.Patient.User.FirstName} {patienthistory.Patient.User.LastName}",
             };

        }
        public static PrescreptionDetailsViewModel MapToPrescreptionDetailsVM(PatientHistory patienthistory)
        {
            return new PrescreptionDetailsViewModel()
            {
                //patient

                PatientId = patienthistory.PatientId,
                Email = patienthistory.Patient.User.Email,
                PatientName = $"{patienthistory.Patient.User.FirstName} {patienthistory.Patient.User.LastName}",
                PhoneNumber = patienthistory.Patient.User.PhoneNumber,
                BirthDate=patienthistory.Patient.User.BirthDate,            
                //Problem
                PatientHistoryId=patienthistory.Id,
                Problem = patienthistory.Problem,
                Weight=patienthistory.Weight,
                Height=patienthistory.Height,
                BloodPressure=patienthistory.BloodPressure,
                ReExaminatoinDate=patienthistory.ReExaminatoinDate,
                CreatedAt=patienthistory.CreatedAt,
                Note=patienthistory.Note
                

            };

        }
         public static FullPatientHistoryViewModel MapToFullPatientHistoryVM(PatientHistory patienthistory)
        {
            return new FullPatientHistoryViewModel()
            {
                //patient

                PatientId = patienthistory.PatientId,
                PatientEmail = patienthistory.Patient.User.Email,
                PatientName = $"{patienthistory.Patient.User.FirstName} {patienthistory.Patient.User.LastName}",
                PhoneNumber = patienthistory.Patient.User.PhoneNumber,
                BirthDate=patienthistory.Patient.User.BirthDate,            
                //Problem
                Problem = patienthistory.Problem,
                CreatedAt=patienthistory.CreatedAt,
                Id=patienthistory.Id
                

            };

        }

        public static AnalysisViewModel MapToAnalysisVM(PatientHistoryMedicalAnalysis patientHistoryAnalysis)
        {
            return new AnalysisViewModel()
            {
                Id=patientHistoryAnalysis.MedicalAnaylsis.Id,
                Name=patientHistoryAnalysis.MedicalAnaylsis.Name,
                Result=patientHistoryAnalysis.Result
                
            };

        }
        public static AnalysisViewModel MapToAnalysisVM(MedicalAnaylsis anaylsis)
        {
            return new AnalysisViewModel()
            {
                Id=anaylsis.Id,
                Name= anaylsis.Name,
            };

        }

        public static AnalysisViewModel MapToEditPHAnalysisAction(PatientHistoryMedicalAnalysis anaylsis)
        {
            return new AnalysisViewModel()
            {
                Id=anaylsis.MedicalAnaylsisId,
                Name= anaylsis.MedicalAnaylsis.Name,
                Result=anaylsis.Result
            };

        }
        public static DrugViewModel MapToDrugVM(Prescription prescription)
        {
            return new DrugViewModel()
            {
                Id=prescription.Drug.Id,
                Name=prescription.Drug.Name,
                Instructions=prescription.DrugInstruction
                
            };

        }public static DrugViewModel MapToDrugVM(Drug drug)
        {
            return new DrugViewModel()
            {
                Id=drug.Id,
                Name=drug.Name,
                
            };

        }

    }
}
