using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MedicalAnalysisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
