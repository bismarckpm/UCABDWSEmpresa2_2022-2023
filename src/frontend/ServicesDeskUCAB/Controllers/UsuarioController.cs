using Microsoft.AspNetCore.Mvc;

namespace ServicesDeskUCAB.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
