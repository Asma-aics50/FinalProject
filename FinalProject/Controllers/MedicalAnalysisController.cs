using FinalProject.IRepositry;
using FinalProject.Models;
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

    }
}
