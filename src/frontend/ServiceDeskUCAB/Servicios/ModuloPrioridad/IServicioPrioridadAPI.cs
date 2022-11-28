using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.PrioridadDTO;
using ServiceDeskUCAB.Models.ModelsVotos;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioPrioridadAPI 
    {
        Task<List<PrioridadDTO>> Lista();

        Task<List<PrioridadDTO>> ListaHabilitado();

        Task<PrioridadDTO> Obtener(Guid prioridadID);

        Task<JObject> Guardar(PrioridadDTO Objeto);

        Task<JObject> Editar(PrioridadDTO Objeto);
    }
}

