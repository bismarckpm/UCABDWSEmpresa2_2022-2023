using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UsuarioServices _usuarioServices;
        public UsuarioController(DataContext dataContext, UsuarioServices rolServices)
        {
            _dataContext = dataContext;
            _usuarioServices = rolServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(Guid id)
        {
            var usuario = await _usuarioServices.GetById(id);

            if (usuario is null)
                return NotFound(id);

            return usuario;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rolUser = await _usuarioServices.GetById(id);

            if (rolUser is not null)
            {
                await _usuarioServices.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
