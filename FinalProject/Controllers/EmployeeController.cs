using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepositry employeeRepositry;
        public EmployeeController(IEmployeeRepositry employeeRepositry) 
        { 
            this.employeeRepositry = employeeRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllEmployee()
        {
            List<AllEmployeesViewModel> employeesViewModels = employeeRepositry.GetAll_Departments_User().Select(MapRepositry.MapToAllEmployeeVM).ToList();
            
            return View(employeesViewModels);
        }
        public IActionResult EmployeeDetails(int id)
        {
            var emp = employeeRepositry._GetByIdUser(id);
             EmployeeDetailsViewModel employeeDetailsView = new EmployeeDetailsViewModel()
            {
                Name = $"{emp.User.FirstName}{emp.User.LastName}",
                Email = emp.User.Email,
                Gender = emp.User.Gender,
                PhoneNumber = emp.User.PhoneNumber,
                BirthDate = emp.User.BirthDate,
                Salary = emp.Salary,
                Speciatization = emp.Specialization,
                Department = emp.Department.Name

             };
            return View(employeeDetailsView);
        }


    }
    }
