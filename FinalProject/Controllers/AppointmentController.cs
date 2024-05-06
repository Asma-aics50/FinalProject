using FinalProject.IRepositry;
using FinalProject.Services;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AppointmentController : Controller
    {   
            IBookedAppointmentsRepositry bookedAppointmentsRepositry;
            public AppointmentController(
                 
                  IBookedAppointmentsRepositry bookedAppointmentsRepositry
               )
            {
               
                this.bookedAppointmentsRepositry = bookedAppointmentsRepositry;
            }


            [Authorize(Roles = "Admin")]
            public IActionResult AllPatientsAppointment()
            {

            List<AllPatientsAppointmentViewModel> AllPatientsAppointmentVM = bookedAppointmentsRepositry.GetAllAppointments_Patient_Doctor().
                Select(MapRepositry.MapToAllPatientsAppointmentVM).ToList();

            return View(AllPatientsAppointmentVM);
        }
        

            [Authorize(Roles = "Admin")]
            [HttpGet]   
            public IActionResult Create()
            {


         
                return View();
        
             }


    }
}
