using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.Modelos_de_Usuario;
using ServiceDeskUCAB.Servicios;

namespace ServiceDeskUCAB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IServicioUsuario_API _servicioApiUsuarios;

        public LoginController(ILogger<LoginController> logger, IServicioUsuario_API servicioApiUsuarios)
        {
            _logger = logger;
            _servicioApiUsuarios = servicioApiUsuarios;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SingUp()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarCredenciales(Credenciales_Login usuario)
        {
            JObject respuesta;

            try
            {
                respuesta = await _servicioApiUsuarios.ValidarLogin(usuario);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

            [HttpPost]
        public async Task<IActionResult> GuardarUsuario(UsuariosRol plantilla)
        {

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiUsuarios.Guardar(plantilla);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Login", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }
    }
}
