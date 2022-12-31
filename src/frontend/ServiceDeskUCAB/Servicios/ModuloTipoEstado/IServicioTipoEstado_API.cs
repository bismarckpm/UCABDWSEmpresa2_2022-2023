
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.EstadoTicket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDeskUCAB.Servicios.ModuloTipoEstado
{
    public interface IServicioTipoEstado_API
    {
        Task<List<TipoEstado>> Lista();
        Task<List<TipoEstado>> ListaHabilitados();
        Task<List<Etiqueta>> ListaEtiqueta();
        Task<JObject> Guardar(TipoEstadoNuevo tipoEstadoRegistro);
        Task<JObject> HabilitarDeshabilitar(Guid idEstado);
        Task<TipoEstado> Obtener(Guid idEstado);
        Task<JObject> Editar(TipoEstadoNuevo estado, string Id);
        //Task<JObject> Eliminar(Guid idEstado);

    }
}
