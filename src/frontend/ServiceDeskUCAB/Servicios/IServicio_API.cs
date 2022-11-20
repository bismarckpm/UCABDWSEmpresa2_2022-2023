using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();

        Task<ApplicationResponse<Tipo_TicketDTOCreate>> Guardar(Tipo_TicketDTOCreate tipo);

       
        Task<bool> Eliminar(Guid id);

        Task<List<Departament>> ListaDepa();

        Task<List<TipoCargo>> ListaCargos();
        Task<ApplicationResponse<Tipo_TicketDTOUpdate>> Actualizar(Tipo_TicketDTOUpdate tipoTicketDTO);
    }
}
