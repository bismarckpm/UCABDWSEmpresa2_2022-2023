using ModuloPlantillasNotificaciones.Models.PlantillaNotificaciones;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuloPlantillasNotificaciones.Servicios
{
    public interface IServicioPlantillaNotificacion_API
    {
        Task<List<PlantillaNotificacion>> Lista();
        Task<PlantillaNotificacion> Obtener(Guid idPlantilla);
        Task<JObject> Guardar(PlantillaNotificacionNueva plantilla);
        Task<JObject> Editar(PlantillaNotificacionNueva plantilla, string id);
        Task<JObject> Eliminar(Guid idPlantilla);
    }
}
