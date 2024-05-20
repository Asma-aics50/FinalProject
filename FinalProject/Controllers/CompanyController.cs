﻿using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyRepositry companyRepositry;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        public CompanyController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn, ICompanyRepositry companyRepositry) 
        {
            this.userManager = userManager;
            this.signIn = signIn;
           
            this.companyRepositry = companyRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateCompany(CreateCompanyViewModel createCompanyView)
        {
            Company company=new Company() { Id = createCompanyView.Id,Name = createCompanyView.Name,Specialization=createCompanyView.Specialization,ZipCode = createCompanyView.ZipCode,Street=createCompanyView.Street,City= createCompanyView.Street };
            companyRepositry.Create(company);
            return View("AllCompany");
        }

        public IActionResult AllCompany() 
        {
            List<AllCompanyViewModel> allCompanies = companyRepositry.GetAll().Select(MapRepositry.MapToAllCompanyVM).ToList();

            return View(allCompanies);  
        }
    }
}
