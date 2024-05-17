using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ServiseController : Controller
    {
        IServiceRepositry serviceRepositry;

        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;
        public ServiseController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn, IServiceRepositry serviceRepositry) 
        {
            this.userManager = userManager;
            this.signIn = signIn;
            this.serviceRepositry = serviceRepositry;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateServices()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateServices(CreateServiceViewModel createServiceView)
        {
           
                Service service = new Service() { Id = createServiceView.Id, Name = createServiceView.Name, Price = createServiceView.Price };
                serviceRepositry.Create(service);
               
            
            return RedirectToAction("AllServices");
        }
        public IActionResult AllServices() 
        {
            List<AllServicesViewModel> services = serviceRepositry.GetAll().Select(MapRepositry.MapToAllServicesVM).ToList();

            return View(services);
        }
    }
}
