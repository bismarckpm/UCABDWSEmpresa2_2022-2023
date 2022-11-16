using ServicesDeskUCABWS.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioUsuario_API
    {
        Task<List<Usuarios>> Lista();
        Task<JObject> Guardar(Usuarios usuarios);
        Task<JObject> Eliminar(Guid id);
    }
}
