using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
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
        private readonly IUserLoginDAO _userLoginDAO;
        private readonly ILogger<UsuarioController> _log;


        public UsuarioController(IUsuarioDAO usuarioDao, IUserLoginDAO userLogin)
        {
            _usuarioDAO = usuarioDao;
            _userLoginDAO = userLogin; 
        }


      
        [HttpGet]
        public ApplicationResponse<List<Usuario>> ConsultarUsuarios()
        {
            var response = new ApplicationResponse<List<Usuario>>();
            try
            {
                response.Data= _usuarioDAO.ObtenerUsuarios();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet]
        [Route("ConsultarEmpleado/")]
        public ApplicationResponse<List<UsuarioGeneralDTO>> ConsultarEmpleados()
        {
            var response = new ApplicationResponse<List<UsuarioGeneralDTO>>();
            try
            {
                response.Data = _usuarioDAO.ObtenerEmpleados();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost]
        [Route("CrearAdministrador/")]
        public ApplicationResponse<Administrador> CrearAdministrador([FromBody] UsuarioDto Usuario)
        {
            var response = new ApplicationResponse<Administrador>();
            try
            {
                var resultService = _usuarioDAO.AgregarAdminstrador(UserMapper.MapperEntityToDtoAdmin(Usuario));
                response.Data = resultService;

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        [HttpPost]
        [Route("CrearCliente/")]
        public ApplicationResponse<Cliente> CrearCliente([FromBody] UsuarioDto Usuario)
        {
            var response = new ApplicationResponse<Cliente>();
            try
            {
                response.Data = _usuarioDAO.AgregarCliente(UserMapper.MapperEntityToDtoClient(Usuario));

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost]
        [Route("CrearEmpleado/")]
        public ApplicationResponse<Empleado> CrearEmpleado([FromBody] UsuarioDto Usuario)
        {
            var response = new ApplicationResponse<Empleado>();
            try
            {
                var resultService = _usuarioDAO.AgregarEmpleado(UserMapper.MapperEntityToDtoEmp(Usuario));
                response.Data = resultService;

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost]
        [Route("RecuperarClave")]
        public ApplicationResponse<string> RecuperarClave([FromBody] UserRecoveryDTO usuario)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                
                response.Message = _usuarioDAO.RecuperarClave(usuario.email);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }
        /*
        [HttpPost]
        [Route("ValidarUsuario")]
        public ApplicationResponse<string> ValidarContraseña([FromRoute] string email)
        {
            var response = new ApplicationResponse<string>();
            try
            {
               
                 response.Message = _usuarioDAO.ValidarCorreo(email);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;


        }*/

        [HttpGet]
        [Route("Consulta/Usuario/{id}")]
        public ApplicationResponse<Usuario> GetByTipoUsuarioId(Guid id)
        {
            var response = new ApplicationResponse<Usuario>();
            try
            {
                response.Data = _usuarioDAO.consularUsuarioID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet]
        [Route("Consulta/Empleado/{id}")]
        public ApplicationResponse<Empleado> GetByTipoEmpleadoId(Guid id)
        {
            var response = new ApplicationResponse<Empleado>();
            try
            {
                response.Data = _usuarioDAO.consularEmpleadoID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }


        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public ApplicationResponse<UsuarioDto> EliminarUsuario([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<UsuarioDto>();
            try
            {
                var resultService = _usuarioDAO.eliminarUsuario(id);
                response.Data = resultService;

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPut]
   
        [Route("ActualizarUsuario/")]
        public ApplicationResponse<UserDto_Update> ActualizarUsuario([FromBody] UserDto_Update usuario)
        {
            var response = new ApplicationResponse<UserDto_Update>();
            try
            {
                var resultService = _usuarioDAO.ActualizarUsuario(UserMapper.MapperEntityToDtoUpdate(usuario));
                response.Data = resultService;

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        /*[HttpPut]
        [Route("ActualizarUsuarioPassword/")]
        public ApplicationResponse<String> ActualizarPassword([FromBody] UserPasswordDto usuario)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = _usuarioDAO.ActualizarUsuarioPassword(UserMapper.MapperEntityToDtoUpdatePassword(usuario));
                response.Data = resultService.ToString();

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/

        [HttpPost]
        [Route("login/")]
        public ApplicationResponse<UserResponseLoginDTO> UserLogin([FromBody]  UserLoginDto usuario )
        {
            var response = new ApplicationResponse<UserResponseLoginDTO>();
            try
            {
                response.Data = _userLoginDAO.UserLogin(usuario);
            }
            catch (ExceptionsControl ex )
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost]
        [Route("AsignarCargo/")]
        public ApplicationResponse<UsuarioDTOAsignarCargo> AsignarCargo([FromBody] UsuarioDTOAsignarCargo usuario)
        {
            var response = new ApplicationResponse<UsuarioDTOAsignarCargo>();
            try
            {
                response.Data = _usuarioDAO.AsignarCargo(usuario);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                //response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost]
        [Route("RevocarCargo/")]
        public ApplicationResponse<string> RevocarCargo([FromBody] Guid idusuario)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                response.Data = _usuarioDAO.RevocarCargo(idusuario);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                //response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}
