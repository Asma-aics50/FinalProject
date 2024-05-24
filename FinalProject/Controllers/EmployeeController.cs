using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var editemployee = employeeRepositry._GetByIdUser(id);
            EditEmployeeViewModel editEmployeeView = new EditEmployeeViewModel() 
            {
                FirstName = editemployee.User.FirstName,
                LastName = editemployee.User.LastName,
                Email = editemployee.User.Email,
                UserName = editemployee.User.UserName,
                BirthDate = editemployee.User.BirthDate,
                Salary = editemployee.Salary,
                Gender = editemployee.User.Gender
            };
            if (editemployee == null) 
            {
                return RedirectToAction("AllEmployee");
            }
            return View(editEmployeeView);
        }
       
        [HttpPost]

        public IActionResult EditEmployee(EditEmployeeViewModel editEmployeeView) 
        {
            if (ModelState.IsValid)
            {
                employeeRepositry.UpdateeEiteEmployee(editEmployeeView);      
                return RedirectToAction("AllEmployee");
            }
            return View(editEmployeeView);  
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEmployee(int id)
        {
            employeeRepositry.Delete(id);
            return RedirectToAction("AllEmployee");
        }

    }

}
