using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCAB.Models;
namespace ServicesDeskUCAB.Servicios.Prioridad
{
    public interface IServicioAPI 
    {
        Task<List<Models.Prioridad>> Lista();

        Task<List<Models.Prioridad>> ListaEstado(string cadena);

        Task<Models.Prioridad> Obtener(int PrioridadID);

        Task<bool> Guardar(Models.Prioridad Objeto);

        Task<bool> Editar(Models.Prioridad Objeto);
    }
}

