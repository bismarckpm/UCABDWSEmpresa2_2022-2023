using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.PlantillaNotificaciones;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDeskUCAB.Servicios.ModuloPlantillaNotificacion
{
    public interface IServicioPlantillaNotificacion_API
    {
        Task<List<PlantillaNotificacion>> Lista();
        Task<PlantillaNotificacion> Obtener(Guid idPlantilla);
        Task<JObject> Editar(PlantillaNotificacionNueva plantilla, string id);
        Task<JObject> Eliminar(Guid idPlantilla);
    }
}
