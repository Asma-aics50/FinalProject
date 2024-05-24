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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditServices(int id ) 
        {
            var editserv = serviceRepositry.GetById(id);    
            EditServicesViewModel editServicesView = new EditServicesViewModel() 
            {
                Id = editserv.Id,
                Name = editserv.Name,
                Price = editserv.Price
            };   
            return View(editServicesView);
        }
        public IActionResult EditServices(EditServicesViewModel editServicesView) 
        {
            if (ModelState.IsValid)
            {
                serviceRepositry.UpdateEditServices(editServicesView);
                return RedirectToAction("AllServices");
            }

            return View(editServicesView);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            serviceRepositry.Delete(id);
            return RedirectToAction("AllServices");
        }

    }
}
