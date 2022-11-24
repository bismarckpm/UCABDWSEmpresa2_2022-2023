using ModuloPlantillasNotificaciones.Models.EstadoTicket;
using ModuloPlantillasNotificaciones.Models.PlantillaNotificaciones;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModuloPlantillasNotificaciones.Servicios
{
    public interface IServicioTipoEstado_API
    {
        Task<List<TipoEstado>> Lista();
        Task<List<Etiqueta>> ListaEtiqueta();
        Task<JObject> Guardar(TipoEstadoNuevo tipoEstadoRegistro);
        Task<JObject> Eliminar(Guid idEstado);
        Task<TipoEstado> Obtener(Guid idEstado);
        Task<JObject> Editar(TipoEstadoNuevo estado, String Id);

    }
}
