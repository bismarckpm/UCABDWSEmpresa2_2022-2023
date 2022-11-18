using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioUsuario_API
    {
        Task<List<UsuariosRol>> Lista();
        Task<JObject> Guardar(UsuariosRol usuarios);
        Task<JObject> Eliminar(Guid id);
        Task<JObject> GuardarEmpleado(UsuariosRol usuarios);
        Task<JObject> GuardarAdminstrador(UsuariosRol usuarios);
        Task<UsuariosRol> MostrarInfoUsuario(Guid id);
        Task<JObject> EditarUsuario(UsuariosRol user);
        Task<Roles> ObtenerRoles(Guid roles);

    }
}
