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

        public AsignacionRolController(IUserRol userRol)
        {
            _userRol = userRol;

        }

        [HttpGet]
        [Route("AsignacionRol/{id}")]
        public ApplicationResponse<RolUsuarioDTO> GetRolByUser(Guid id)
        {
            var response = new ApplicationResponse<RolUsuarioDTO>();
            try
            {
                response.Data = _userRol.consularRolID(id);
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
        [Route("EliminarRol/{user}/{rol}")]
        public ApplicationResponse<RolUsuarioDTO> CrearDepartamento([FromRoute] Guid user, [FromRoute] Guid rol)
        {
            var response = new ApplicationResponse<RolUsuarioDTO>();
            try
            {
                var resultService = _userRol.EliminarRol(user,rol);
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
        [Route("AsignarRol/")]
        public ApplicationResponse<RolUsuarioDTO> CrearRolUsuario([FromBody] RolUsuarioDTO userol)
        {
            var response = new ApplicationResponse<RolUsuarioDTO>();
            try
            {
                var resultService = _userRol.AgregarRol(UserRolMapper.MapperEntityToDtoUR(userol));
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
