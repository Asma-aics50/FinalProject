using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        
            UserManager<ApplicationUser> userManager;
            SignInManager<ApplicationUser> signIn;
            IPatientRepositry patientRepositry;
            IDoctorRepositry doctorRepositry;
            IEmployeeRepositry employeeRepositry;

            public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn,
                IPatientRepositry patientRepositry,
                IDoctorRepositry doctorRepositry,
                IEmployeeRepositry employeeRepositry
             )
            {
                this.userManager = userManager;
                this.signIn = signIn;
                this.patientRepositry= patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry= employeeRepositry;
            }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        public async Task<IActionResult> Registration(RegistrationViewModel userVM)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser() {
                    UserName  =new MailAddress(userVM.Email).User,
                    Email = userVM.Email,
                    PasswordHash = userVM.Password,
                    FirstName=userVM.FirstName,
                    LastName=userVM.LastName ,
                    Gender=userVM.Gender.ToString()
                };

                var result = await userManager.CreateAsync(user, userVM.Password);
                //await userManager.AddToRoleAsync(user, "User");

                if (result.Succeeded)
                {
                    await signIn.SignInAsync(user, false);
                    Patient patient=new Patient() { UserId=user.Id };
                    patientRepositry.Create(patient);                    
                    return RedirectToAction("Index", "Home");

                }
                return View();
            }

            return View();
        }

        [HttpGet]

        public IActionResult CreateAccount()
        {
            return View();
        }



        public async Task<IActionResult> CreateAccount(CreateAccountViewModel userVM)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    PasswordHash = userVM.Password,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Gender = userVM.Gender.ToString(),
                    BirthDate=userVM.BirthDate
                };

                var result = await userManager.CreateAsync(user, userVM.Password);



                    await userManager.AddToRoleAsync(user,userVM.Role);
                if (result.Succeeded)
                {

                    if (userVM.Role == "Patient")
                    {

                        Patient patient = new Patient() { UserId = user.Id };
                        patientRepositry.Create(patient);
                    }

                    //else if (userVM.Role == "Doctor")
                    //{


                    //    Doctor doctor = new Doctor() { UserId = user.Id };
                    //    doctorRepositry.Create(doctor);

                    //}

                    //else if (userVM.Role == "Employee"|| userVM.Role== "Admin")
                    //{
                     
                    //    Employee employee = new Employee() { UserId = user.Id,Specialization=null };

                    //    //employeeRepositry.Create(employee);

                    //}

                    return RedirectToAction("Index", "Home");

                }
                return View();
            }

            return View();
        }
    }


}
