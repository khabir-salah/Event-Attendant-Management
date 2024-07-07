using Attendee.DTO;
using Attendee.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Attendee.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IAttendeeService _attendeeService;
        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpPost]
        public IActionResult Register( AttendeeRequestModel request)
        {
            var attendee = _attendeeService.Register(request);
            if(attendee != null)
            {
                TempData["Successfull"] = "Registration Successfull";
            }
            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAttendee(string name)
        {
            var get = _attendeeService.GetAttendee(name);
            return View(get);
        }

        [HttpGet]
        public IActionResult GetAttendee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IsCheckedOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IsCheckout(string name)
        {
            var checkout = _attendeeService.IsCheckedOut(name);
            return View(checkout);
        }

        [HttpGet]
        public IActionResult IsSteppedOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IsSteppedOut(string name)
        {
            var checkout = _attendeeService.IsSteppedOut(name);
            return View(checkout);
        }

        [HttpGet]
        public IActionResult StepOutOnce()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StepOutOnce(string name)
        {
            var checkout = _attendeeService.StepOutOnce(name);
            return View(checkout);
        }


    }
}
