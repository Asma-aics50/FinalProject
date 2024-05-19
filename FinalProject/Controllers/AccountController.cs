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
        IDepartmentRepositry departmentRepositry;



        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn,
                IPatientRepositry patientRepositry,
                IDoctorRepositry doctorRepositry,
                IEmployeeRepositry employeeRepositry,

        IDepartmentRepositry departmentRepositry
            //HospitalManagementSystemDbContext context
             )
            {
            //this.context = context;
                this.userManager = userManager;
                this.signIn = signIn;
                this.patientRepositry= patientRepositry;
            this.doctorRepositry = doctorRepositry;
            this.employeeRepositry= employeeRepositry;
            this.departmentRepositry = departmentRepositry;
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
                // If creation failed, add model errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
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
                    BirthDate=userVM.BirthDate,
                    PhoneNumber = userVM.Phone
                };

                var result = await userManager.CreateAsync(user, userVM.Password);

               
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Patient");
                    Patient patient = new Patient() { UserId = user.Id };
                        patientRepositry.Create(patient);
                        return RedirectToAction("AdminIndex", "Dashboard"); // change to dashboord

                }
                // If creation failed, add model errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            

            return View();
        }
        //Authorize admin
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateEmployeeAccount()
        {
            ViewBag.Departments = departmentRepositry.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployeeAccount(CreateEmployeeAccountViewModel userVM)
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
                    BirthDate = userVM.BirthDate,
                    PhoneNumber = userVM.Phone
                    
                };
                var result = await userManager.CreateAsync(user, userVM.Password);

                await userManager.AddToRoleAsync(user,userVM.Role);

                if (result.Succeeded)
                {

                    Employee employee = new Employee() { UserId = user.Id,DepartmentId=userVM.DeptId,Salary=userVM.Salary, Specialization=userVM.Specialization };
                    employeeRepositry.Create(employee);
                    return RedirectToAction("AdminIndex", "Dashboard"); // change to dashboord
                }

                // If creation failed, add model errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewBag.Departments = departmentRepositry.GetAll();
            return View();

        }


        //create Doctors account // for admin
        
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDoctorAccount()
        {
            ViewBag.Departments = departmentRepositry.GetAll();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDoctorAccount(CreateDoctorAccountViewModel userVM)
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
                    BirthDate = userVM.BirthDate,
                    PhoneNumber = userVM.Phone
                };

                var result = await userManager.CreateAsync(user, userVM.Password);



                

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Doctor");
                    Doctor doctor = new Doctor() { UserId = user.Id,
                        DepartmentId = userVM.DeptId,
                        Salary = userVM.Salary, 
                        Specialization = userVM.Specialization ,
                        ShiftEndTime=userVM.ShiftEndTime,
                        ShiftStartTime=userVM.ShiftStartTime,
                        Medical_License_no=userVM.Medical_License_no
                    };
                    doctorRepositry.Create(doctor);
                    return RedirectToAction("AdminIndex", "Dashboard"); // change to dashboord
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewBag.Departments = departmentRepositry.GetAll();
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

                        if (User.IsInRole("Admin"))
                        {
                            return RedirectToAction("AdminIndex", "Dashboard");
                        }
                        else if(User.IsInRole("Doctor"))

                        {
                        
                        return RedirectToAction("DoctorIndex","Dashboard" );
                        }

                        return RedirectToAction("Index","Home" );
                       
                    }

                    //

                    ModelState.AddModelError("notValidPasswordOrEmail", "Invalid Username or Password");

                }

                else
                {
                    ModelState.AddModelError("invalidUserNameOrPassword", "Invalid Username or Password");
                }
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
