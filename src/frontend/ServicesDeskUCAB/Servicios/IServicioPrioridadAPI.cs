using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
namespace ServicesDeskUCAB.Servicios
{
    public interface IServicioPrioridadAPI 
    {
        Task<List<Prioridad>> Lista();

        Task<List<Prioridad>> ListaEstado(string cadena);

        Task<Prioridad> Obtener(Guid prioridadID);

        Task<JObject> Guardar(Prioridad Objeto);

        Task<JObject> Editar(Prioridad Objeto);
    }
}

