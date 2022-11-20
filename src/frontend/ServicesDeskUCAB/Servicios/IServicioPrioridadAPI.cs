using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCAB.Models;
namespace ServicesDeskUCAB.Servicios
{
    public interface IServicioPrioridadAPI 
    {
        Task<List<Models.Prioridad>> Lista();

        Task<List<Models.Prioridad>> ListaEstado(string cadena);

        Task<Models.Prioridad> Obtener(Guid prioridadID);

        Task<bool> Guardar(Prioridad Objeto);

        Task<bool> Editar(Prioridad Objeto);
    }
}

