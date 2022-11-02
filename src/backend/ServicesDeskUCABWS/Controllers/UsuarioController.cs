using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioDAO _usuarioDAO;
        private readonly ILogger<UsuarioController> _log;


        public UsuarioController(IUsuarioDAO usuarioDao, ILogger<UsuarioController> log)
        {
            _usuarioDAO = usuarioDao;
            _log = log;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ConsultarUsuarios()
        {
            try
            {
                return _usuarioDAO.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("CrearAdministrador/")]
        public ActionResult<Administrador> CrearAdministrador([FromBody] UsuarioDto Usuario)
        {
            try
            {
                var dao = _usuarioDAO.AgregarAdminstrador(UserMapper.MapperEntityToDtoAdmin(Usuario));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
        [HttpPost]
        [Route("CrearCliente/")]
        public ActionResult<Cliente> CrearCliente([FromBody] UsuarioDto Usuario)
        {
            try
            {
                var dao = _usuarioDAO.AgregarCliente(UserMapper.MapperEntityToDtoClient(Usuario));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("CrearEmpleado/")]
        public ActionResult<Empleado> CrearEmpleado([FromBody] UsuarioDto Usuario)
        {
            try
            {
                var dao = _usuarioDAO.AgregarEmpleado(UserMapper.MapperEntityToDtoEmp(Usuario));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public ActionResult<UsuarioDto> EliminarDepartamento([FromRoute] Guid id)
        {
            try
            {
                return _usuarioDAO.eliminarUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("ActualizarUsuario/")]
        public ActionResult<UserDto_Update> ActualizarUsuario([FromBody] UserDto_Update usuario)
        {
            try
            {
                return _usuarioDAO.ActualizarUsuario(UserMapper.MapperEntityToDtoUpdate(usuario));
                //Cambiar parametros cuando realicemos frontend

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("ActualizarUsuarioPassword/")]
        public ActionResult<UserPasswordDto> ActualizarPassword([FromBody] UserPasswordDto usuario)
        {
            try
            {
                return _usuarioDAO.ActualizarUsuarioPassword(UserMapper.MapperEntityToDtoUpdatePassword(usuario));
                //Cambiar parametros cuando realicemos frontend

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }
}
