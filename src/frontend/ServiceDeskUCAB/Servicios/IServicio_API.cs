using ServiceDeskUCAB.Models;
using ServicesDeskUCAB.Models.TipoTicketModels;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();
        Task<bool> Eliminar(int idProducto);
        Task<bool> Modificar(Tipo tipo_ticket);
        Task<bool> AgregarTicket(NuevoTicket ticket);
        Task<ApplicationResponse<Votos_Ticket>> VotarTicket(VotarTicket voto_ticket);
        Task<List<Ticket>> ListaTickets();

        Task<Tipo> ObtenerTipoTicket(string id_tipo);

        Task<List<Departament>> ObtenerDepartamentos();
        Task<List<Prioridad>> ObtenerPrioridades();


        Task<bool> Guardar(Tipo_TicketDTOCreate tipo);

       
        Task<bool> Eliminar(Guid id);

        Task<List<Departament>> ListaDepa();

        Task<List<TipoCargo>> ListaCargos();
    }
}
