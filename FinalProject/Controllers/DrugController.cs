﻿using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DrugController : Controller
    {
        IDrugRepositry drugRepositry;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        ICompanyRepositry companyRepositry;

        public DrugController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn, IDrugRepositry drugRepositry, ICompanyRepositry companyRepositry)
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.drugRepositry = drugRepositry;
            this.companyRepositry = companyRepositry;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDrug()
        {
            ViewBag.Company = companyRepositry.GetAll();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateDrug(CreateDrugViewModel createDrugView)
        {
            if (ModelState.IsValid)
            {
                Drug drug = new Drug() { Id = createDrugView.Id, Name = createDrugView.Name, Description = createDrugView.Description, Cost = createDrugView.Cost, CompanyId = createDrugView.CompanyId };
                drugRepositry.Create(drug);
               
                return RedirectToAction("AllDrug");
            }
            return View();
        }

        public IActionResult AllDrug()
        {
            List<AllDrugViewModel> Drug = drugRepositry.GetAll().Select(MapRepositry.MapRoAllDrugVM).ToList();
            return View(Drug);
        }


    }
}