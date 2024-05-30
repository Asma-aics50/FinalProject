using FinalProject.IRepositry;
using FinalProject.Models;
using FinalProject.Repositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
        public IActionResult EditServices(int id)
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

        public IActionResult ServicesDetails(int id)
        {
            var details = serviceRepositry.GetById(id);
            ServicesDetailsViewModel detailsViewModel = new ServicesDetailsViewModel()
            {
                Id = details.Id,
                Name = details.Name,
                Price = details.Price,
            };
            return View(detailsViewModel);
        }

        static Dictionary<string, double> cartItems = new Dictionary<string, double>();
        public IActionResult AddToBill(string name, double price)
        {
            if (string.IsNullOrEmpty(name) || price <= 0)
            {
                // Handle invalid cases here
                return BadRequest("Invalid item name or price.");
            }

            // Log or check the name parameter
            Console.WriteLine($"Received name: {name}");

            var bill = serviceRepositry.GetByName(name);
            if (bill == null)
            {
                return NotFound();
            }

            cartItems[name] = bill.Price;

            if (cartItems.Count > 0)
            {
                var listOfServices = JsonSerializer.Serialize(cartItems);
                Response.Cookies.Append("listOfBills", listOfServices);
            }

            return RedirectToAction("AllServices");
        }

        public IActionResult ListOfBills()
        {
            var result = Request.Cookies["listOfBills"];

            Dictionary<string, double> cartItems = new Dictionary<string, double>();

            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    cartItems = JsonSerializer.Deserialize<Dictionary<string, double>>(result);
                }
                catch (JsonException)
                {
                    // Handle error here, such as resetting `cartItems` or logging the error
                    cartItems = new Dictionary<string, double>();
                }
            }

            double totalPrice = cartItems.Sum(item => item.Value);

            ViewData["listOfBills"] = cartItems;
            ViewData["totalPrice"] = totalPrice;

            return View();
        }

    }
}
