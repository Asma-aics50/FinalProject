using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class RoleController : Controller
    {
        
            RoleManager<IdentityRole> roleManager;

            public RoleController(RoleManager<IdentityRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();

            }

            [HttpPost]
            
            public async Task<IActionResult> Create(CreateRoleViewModel roleVm)
            {
                if (ModelState.IsValid)
                {
                    IdentityRole role = new IdentityRole(roleVm.Name);

                    var result = await roleManager.CreateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Role.");
                    }
                }
                return View();

            }
        }
}
