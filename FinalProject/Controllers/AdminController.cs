using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
       
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }

        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new ProfileViewModel
            {
                UserName = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber =user.PhoneNumber,
                Email =user.Email,
                
                
        
            };
            

            return View(model);
        }
    }
}
