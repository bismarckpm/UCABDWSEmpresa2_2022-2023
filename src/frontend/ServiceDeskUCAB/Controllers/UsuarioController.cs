using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.Enums;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServicesDeskUCAB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IServicioUsuario_API _servicioApiUsuarios;

        public UsuarioController(ILogger<UsuarioController> logger, IServicioUsuario_API servicioApiUsuarios)
        {
            _logger = logger;
            _servicioApiUsuarios = servicioApiUsuarios;
        }

        public async Task<IActionResult> Usuarios()
        {
            List<UsuariosRol> ListaPlantillas = await _servicioApiUsuarios.Lista();
            return View(ListaPlantillas);
        }

        public IActionResult GuardarUsuarioView()
        {
            return View("GuardarUsuario");
        }

        public IActionResult RegistrarUsuario()
        {
            return View("~/Views/Login/SingUp");
        }

        public IActionResult VentanaEliminarUsuario(Guid id)
        {
            return PartialView(id);
        }



        [HttpGet]
        public async Task<IActionResult> EliminarUsuario(Guid id)
        {
            JObject respuesta;
            respuesta = await _servicioApiUsuarios.Eliminar(id);
            if ((bool)respuesta["success"])
                return RedirectToAction("Usuarios");
            else
                return NoContent();
        }

        public async Task<IActionResult> ViewUsuario(Guid id)
        {
           
            try
            {
                UsuariosRol usuario = new UsuariosRol();

                usuario = await _servicioApiUsuarios.MostrarInfoUsuario(id);
                var rol = await _servicioApiUsuarios.ObtenerRoles(usuario.id);
                if (rol.idrol == new Guid("8C8A156B-7383-4610-8539-30CCF7298161"))
                {
                    usuario.Rol = Rol.Cliente;
                }else if (rol.idrol == new Guid("8C8A156B-7383-4610-8539-30CCF7298162"))
                {
                    usuario.Rol = Rol.Administrador;
                }
                else
                {
                    usuario.Rol = Rol.Usuario;
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> ModificarUsuario(UsuariosRol user)
        {
            try
            {
                JObject respuesta;
                respuesta = await _servicioApiUsuarios.EditarUsuario(user);
                if ((bool)respuesta["success"])
                    return RedirectToAction("Usuario", new { message = "Se ha modificado correctamente" });
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
                if (plantilla.Rol == Rol.Administrador)
                {   

                    respuesta = await _servicioApiUsuarios.GuardarAdminstrador(plantilla);
                }
                else if(plantilla.Rol == Rol.Usuario)
                {
                    respuesta = await _servicioApiUsuarios.GuardarEmpleado(plantilla);
                }
                else 
                {
                    respuesta = await _servicioApiUsuarios.Guardar(plantilla);
                }
                
                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("Usuarios");
                }
                else
                {
                    return RedirectToAction("Usuarios", new { message = (string)respuesta["message"] });
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
