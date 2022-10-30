using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.DAOs.Implementation;
using ServicesDeskUCABWS.Persistence.DAOs.Interface;
using ServicesDeskUCABWS.Persistence.Entities;
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
        public ActionResult<RolUsuarioDTO> CrearDepartamento([FromRoute] Guid user, [FromRoute] Guid rol)
        {
            try
            {
                var dao = _userRol.EliminarRol(user,rol);
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost]
        [Route("AsignarRol/")]
        public ActionResult<RolUsuarioDTO> CrearDepartamento([FromBody] RolUsuarioDTO userol)
        {
            try
            {
                var dao = _userRol.AgregarRol(UserRolMapper.MapperEntityToDtoUR(userol));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        public ActionResult<List<RolUsuarioDTO>> ConsultarUsuarios()
        {
            try
            {
                return _userRol.ObtenerUsuariosRoles();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
}
