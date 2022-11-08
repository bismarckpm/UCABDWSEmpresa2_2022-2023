using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionRolController : ControllerBase
    {
        private readonly IUserRol _userRol;
        private readonly ILogger<UsuarioController> _log;

        public AsignacionRolController(IUserRol userRol, ILogger<UsuarioController> log)
        {
            _userRol = userRol;
            _log = log;
        }

        [HttpDelete]
        [Route("EliminarRol/{user}/{rol}")]
        public ApplicationResponse<String> CrearDepartamento([FromRoute] Guid user, [FromRoute] Guid rol)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = _userRol.EliminarRol(user,rol);
                response.Data = resultService.ToString();

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
        [Route("AsignarRol/")]
        public ApplicationResponse<String> CrearDepartamento([FromBody] RolUsuarioDTO userol)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = _userRol.AgregarRol(UserRolMapper.MapperEntityToDtoUR(userol));
                response.Data = resultService.ToString();

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
        public ApplicationResponse<List<RolUsuarioDTO>> ConsultarUsuarios()
        {
            var response = new ApplicationResponse<List<RolUsuarioDTO>>();
            try
            {
                response.Data = _userRol.ObtenerUsuariosRoles();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}
