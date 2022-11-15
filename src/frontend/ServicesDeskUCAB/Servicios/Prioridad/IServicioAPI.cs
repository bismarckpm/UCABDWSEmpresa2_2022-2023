using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCAB.Models;
namespace ServicesDeskUCAB.Servicios.Prioridad
{
    public interface IServicioAPI 
    {
        Task<List<Models.Prioridad>> Lista();

        Task<Models.Prioridad> Obtener(int PrioridadID);

        Task<bool> Guardar(Models.Prioridad Prioridad);

        Task<Models.Prioridad> Editar(int PrioridadID);
    }
}

