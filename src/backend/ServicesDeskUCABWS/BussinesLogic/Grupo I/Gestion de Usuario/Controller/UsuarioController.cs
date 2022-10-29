using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
            using (var context = _dataContext)
            {
                var result = (List<Usuario>)_dataContext.Usuarios
                    .Include(RolesUser => RolesUser.Roles)
                    .ToList();
                return result;
            }
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(Guid id)
        {
            var item = _dataContext.Usuarios
              .Include(i => i.Roles)
              .FirstOrDefault(x => x.Id == id);
            

            if (item is null)
                return NotFound(id);

            return item;
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

        [HttpPost("/Cliente")]
        public async Task<IActionResult> CreateC(UsuarioDto user)
        {
            //var Rolsid = user.Rol;
            var newUser = await _usuarioServices.CreateC(user);
            var UsuarioClient = new RolUsuario
            {
                UserId = newUser.Id,
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298161")
            };
            _dataContext.RolUsuarios.Add(UsuarioClient);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser) ;
        }

        [HttpPost("/Administrador")]
        public async Task<IActionResult> CreateA(UsuarioDto user)
        {
            //var Rolsid = user.Rol;
            var newUser = await _usuarioServices.CreateA(user);
            var UsuarioClient = new RolUsuario
            {
                UserId = newUser.Id,
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298162")
            };
            _dataContext.RolUsuarios.Add(UsuarioClient);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }
    }
}
