using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using ServiceDeskUCAB.Models.Modelos_de_Usuario;
using ServiceDeskUCAB.Servicios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Nodes;

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
            var current = User.Identities.First().Claims;
            if (current.Count()==0)
            {
                Console.WriteLine("asdasdadas");
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
        public IActionResult SingUp()
        {
            return PartialView();
        }
        public IActionResult RecuperarPassword()
        {
            return View();
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
                    //var resultjson = JsonConvert.DeserializeObject<JObject>(respuesta);
                    string stringUser = respuesta["data"].ToString();
                    var result = JsonConvert.DeserializeObject<TokenUser>(stringUser);


                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(result.token);

                    // THIS CODE HERE, MAKE THE "MAGIC"...
                    var userPrincipal = new ClaimsPrincipal(
                        new ClaimsIdentity(token.Claims, "myClaims")
                    );
                    await HttpContext.SignInAsync(userPrincipal);

                    Console.WriteLine(userPrincipal);
                    Response.Cookies.Append("bearer", result.token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine((string)respuesta["message"]);
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
                    return RedirectToAction("Login", new { message3 = "El usuario ha sido registrado" });
                }
                else
                {
                    return RedirectToAction("Login", new { message2 = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RecuperarContraseña(RecuperarPasswordModel usuario)
        {
            try
            {
                //var token = await UserManager.GenerateTwoFactorTokenAsync(usuario,String)
                //usuario.link = ""
                var repuesta = await _servicioApiUsuarios.RecuperarContraseña(usuario);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
