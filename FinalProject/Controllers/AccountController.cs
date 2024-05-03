using FinalProject.Data;
using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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


        

        // for patient
        [HttpGet] 
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

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

                 if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(user, "Patient");
                    await signIn.SignInAsync(user, false);
                    Patient patient=new Patient() { UserId=user.Id };
                    
                    patientRepositry.Create(patient);                    
                    return RedirectToAction("Index", "Home");

                }
                return View();
            }

            return View();
        }

        //Authorize admin
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePatientAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePatientAccount(CreateAccountViewModel userVM)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser()
                {

                    UserName = userVM.UserName,
                    Email = userVM.Email, //Allow null
                    PasswordHash = userVM.Password,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Gender = userVM.Gender.ToString(),
                    BirthDate=userVM.BirthDate
                };

                var result = await userManager.CreateAsync(user, userVM.Password);



                    await userManager.AddToRoleAsync(user,"Patient");
                if (result.Succeeded)
                {
                        Patient patient = new Patient() { UserId = user.Id };
                        patientRepositry.Create(patient);
                        return RedirectToAction("Index", "Home");
                }
                return View();
            }

            return View();
        }


        //create Doctors account // for admin
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDoctorAccount()
        {
            return View();
        }



        //Login
        [HttpGet]
       public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> LogIn(LogInViewModel userVm)
        {
            if (ModelState.IsValid)
            {

                var username = new EmailAddressAttribute().IsValid(userVm.UserName) ? new MailAddress(userVm.UserName).User : userVm.UserName; 
                var user = await userManager.FindByNameAsync(username);
                if (user != null)
                {
                    bool check = await userManager.CheckPasswordAsync(user, userVm.Password);
                    if (check)
                    {
                        await signIn.SignInAsync(user, userVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                
                    }
                }
                
                //

                ModelState.AddModelError("notValidPasswordOrEmail", "Invalid Username or Password");


            }
            else
            {
                ModelState.AddModelError("invalidUserNameOrPassword", "Invalid Username or Password");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await signIn.SignOutAsync();

            return RedirectToAction("Index", "Home");


        }
    }


}
