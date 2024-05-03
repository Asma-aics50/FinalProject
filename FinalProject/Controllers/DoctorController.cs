using FinalProject.IRepositry;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DoctorController : Controller
    {
        
        IDoctorRepositry doctorRepositry;
        
        public DoctorController(
           
            IDoctorRepositry doctorRepositry
           )
        {
           
            this.doctorRepositry = doctorRepositry;
           }

        public IActionResult Index()
        {

            return View();
        }
    }
}
