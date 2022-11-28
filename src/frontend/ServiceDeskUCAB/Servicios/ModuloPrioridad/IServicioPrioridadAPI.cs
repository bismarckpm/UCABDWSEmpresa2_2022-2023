using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioPrioridadAPI 
    {
        Task<List<Prioridad>> Lista();

        Task<List<Prioridad>> ListaHabilitado();

        Task<Prioridad> Obtener(Guid prioridadID);

        Task<JObject> Guardar(Prioridad Objeto);

        Task<JObject> Editar(Prioridad Objeto);
    }
}

