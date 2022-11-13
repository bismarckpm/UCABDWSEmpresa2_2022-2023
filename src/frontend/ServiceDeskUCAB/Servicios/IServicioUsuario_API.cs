using ServicesDeskUCABWS.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioUsuario_API
    {
        Task<List<Usuarios>> Lista();
    }
}
