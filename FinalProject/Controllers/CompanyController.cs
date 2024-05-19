using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
