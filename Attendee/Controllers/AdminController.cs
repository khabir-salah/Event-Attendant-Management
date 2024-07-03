using Microsoft.AspNetCore.Mvc;

namespace Attendee.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
