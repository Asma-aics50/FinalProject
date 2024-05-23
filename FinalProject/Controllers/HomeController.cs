using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IDoctorRepositry doctorRepositry;

        public HomeController(ILogger<HomeController> logger,
        IDoctorRepositry doctorRepositry)
        {
            _logger = logger;
            this.doctorRepositry = doctorRepositry;
        }

        public IActionResult Index()
        {
           ViewBag.doctors = doctorRepositry.GetAll_Departments_User().Select(MapRepositry.MapToDoctorsVM).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}