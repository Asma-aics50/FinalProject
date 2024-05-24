using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MedicalAnalysisController : Controller
    {
        IMedicalAnalysisRepositry medicalAnalysisRepositry;
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        public MedicalAnalysisController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn,IMedicalAnalysisRepositry medicalAnalysisRepositry) 
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.medicalAnalysisRepositry = medicalAnalysisRepositry;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateMedicalAnalysis()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateMedicalAnalysis(CreateMedicalAnalysisViewModel createMedicalAnalysisView)
        {
            MedicalAnaylsis medicalAnaylsis = new MedicalAnaylsis() {Id = createMedicalAnalysisView.Id,Name = createMedicalAnalysisView.Name };
            medicalAnalysisRepositry.Create(medicalAnaylsis);
            return RedirectToAction("AllMedicalAnalysis");
        }
        public IActionResult AllMedicalAnalysis() 
        {
            List<AllMedicalAnalysis> medicalAnalyses=medicalAnalysisRepositry.GetAll().Select(MapRepositry.MapToAllMedicalAnalysisVM).ToList();
            return View(medicalAnalyses);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditMedicalAnalysis(int id )
        {
            var editMedical = medicalAnalysisRepositry.GetById(id);
            EditMedicalAnalysisViewModel edit = new EditMedicalAnalysisViewModel() 
            { 
                Id = editMedical.Id,    
                Name = editMedical.Name

            };
            return View(edit);
        }
        [HttpPost]
        public IActionResult EditMedicalAnalysis(EditMedicalAnalysisViewModel editMedicalAnalysis) 
        {
            if (ModelState.IsValid)
            {
                medicalAnalysisRepositry.UpdateEdit(editMedicalAnalysis);
                return RedirectToAction("AllMedicalAnalysis");
            }
            return View(editMedicalAnalysis);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            medicalAnalysisRepositry.Delete(id);
            return RedirectToAction("AllMedicalAnalysis");
        }
    }
}
