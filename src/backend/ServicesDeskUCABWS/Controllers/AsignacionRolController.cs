using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Services;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionRolController : ControllerBase
    {/*
        private readonly DataContext _dataContext;
        private readonly AsignacionRolServices _asignacionRolServices;
        public AsignacionRolController(DataContext dataContext, AsignacionRolServices asignacionRolServices)
        {
            _dataContext = dataContext;
            _asignacionRolServices = asignacionRolServices;
        }

        [HttpGet]
        public async Task<IEnumerable<RolUsuario>> Get()
        {
            return await _asignacionRolServices.GetAll();
        }

        [HttpPost("/AsignarRol")]
        public async Task<IActionResult> Create(UsuarioRolDto user)
        {
            //var Rolsid = user.Rol;
            var newUserRol = await _asignacionRolServices.Create(user);
            return CreatedAtAction("Get", new { id = newUserRol.UserId }, newUserRol);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid idUser, Guid idRol)
        {
            return null;
        }
        */
    }
}
