using FinalProject.IRepositry;
using FinalProject.Repositry;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DashboardController : Controller
    {
      
            IPatientRepositry patientRepositry;
            IDoctorRepositry doctorRepositry;
        IBookedAppointmentsRepositry bookedAppointmentsRepositry;
        IEmployeeRepositry employeeRepositry;
        IPatientHistoryRepositry PatientHistoryRepositry;
        IBillRepositry BillRepositry;
        IDrugRepositry DrugRepositry;
        ICompanyRepositry CompanyRepositry;
        IMedicalAnalysisRepositry MedicalAnalysisRepositry;
        IServiceRepositry ServiceRepositry;
        IDepartmentRepositry DepartmentRepositry;
        public DashboardController(
              IPatientRepositry patientRepositry,
              IDoctorRepositry doctorRepositry,
              IBookedAppointmentsRepositry bookedAppointmentsRepositry,
              IEmployeeRepositry employeeRepositry,
              IPatientHistoryRepositry patientHistoryRepositry,
              IBillRepositry BillRepositry,
              IDepartmentRepositry departmentRepositry,
              IDrugRepositry drugRepositry,
              IServiceRepositry serviceRepositry,
              IMedicalAnalysisRepositry medicalAnalysisRepositry,
              ICompanyRepositry companyRepositry


               )
            {
                this.patientRepositry = patientRepositry;
                this.doctorRepositry = doctorRepositry;
                this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
                this.employeeRepositry = employeeRepositry;
                this.PatientHistoryRepositry = patientHistoryRepositry;
                this.BillRepositry = BillRepositry;
                this.DrugRepositry = drugRepositry;
            this.CompanyRepositry = companyRepositry;
            this.MedicalAnalysisRepositry = medicalAnalysisRepositry;
            this.ServiceRepositry = serviceRepositry;
            this.DepartmentRepositry = departmentRepositry;

            }

            public IActionResult AdminIndex()
            {
                ViewData["DoctorsNum"] = doctorRepositry.GetAll().ToList().Count();
                ViewData["PatientsNum"] = patientRepositry.GetAll().ToList().Count();
                ViewData["AppointmnetsNum"] = bookedAppointmentsRepositry.GetAll().ToList().Count();
                ViewData["employeesNum"] = employeeRepositry.GetAll().ToList().Count();
                ViewData["DrugsNum"] = DrugRepositry.GetAll().ToList().Count();
                ViewData["CompanyNum"] = CompanyRepositry.GetAll().ToList().Count();
                ViewData["MedicalAnalysisNum"] = MedicalAnalysisRepositry.GetAll().ToList().Count();
                ViewData["ServicesNum"] = ServiceRepositry.GetAll().ToList().Count();
                ViewData["DepartmentNum"] = DepartmentRepositry.GetAll().ToList().Count();

                return View();

            }
            public IActionResult DoctorIndex()
            {
                ViewData["DoctorsNum"] = doctorRepositry.GetAll().ToList().Count();
                ViewData["PatientsNum"] = patientRepositry.GetAll().ToList().Count();
                return View();
            }
        public IActionResult PatientIndex()
            {
                
                return View();
            }
        }
    }
