using Microsoft.AspNetCore.Mvc;

namespace ServicesDeskUCABWS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Votos()
        {
            return View();
        }
    }
}
