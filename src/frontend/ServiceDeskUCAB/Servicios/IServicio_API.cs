using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();
        Task<List<Tipo>> ListaxDepartamento(Guid id);
        Task<ApplicationResponse<Votos_Ticket>> VotarTicket(VotarTicket voto_ticket);

        Task<List<Prioridad>> ObtenerPrioridades();
        Task<bool> AgregarTicket(NuevoTicket ticket);

        Task<ApplicationResponse<Tipo_TicketDTOCreate>> Guardar(Tipo_TicketDTOCreate tipo);

       
        Task<bool> Eliminar(Guid id);

        Task<List<Departament>> ListaDepa();

        Task<List<CargoDTOUpdate>> ListaCargos(Guid IdDepartamento);

        Task<List<Votos_Ticket>> ObtenerVotos(string idUsuario);

        Task<ApplicationResponse<Ticket>> ObtenerTicket(string id);
        Task<ApplicationResponse<Tipo_TicketDTOUpdate>> Actualizar(Tipo_TicketDTOUpdate tipoTicketDTO);

        Task<List<Votos_Ticket>> ObtenerVotosNoPendientes(string idUsuario);

        Task<List<Modelo_Aprobacion>> ObtenerListaModelosAprobacion();

    }
}
