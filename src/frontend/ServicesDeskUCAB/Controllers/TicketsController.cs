using Microsoft.AspNetCore.Mvc;

namespace ServicesDeskUCAB.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Votar()
        {
            return View();
        }
    }
}
