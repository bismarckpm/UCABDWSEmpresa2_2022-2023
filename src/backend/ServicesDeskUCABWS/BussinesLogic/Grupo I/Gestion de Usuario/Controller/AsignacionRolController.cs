using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Services;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionRolController : ControllerBase
    {
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
    }
}
