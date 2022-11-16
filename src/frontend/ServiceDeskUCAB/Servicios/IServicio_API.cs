using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();
        Task<bool> Eliminar(int idProducto);
        Task<bool> Modificar(Tipo tipo_ticket);
        Task<bool> AgregarTicket(Ticket ticket);
        Task<bool> VotarTicket(VotarTicket voto_ticket);
        Task<List<Ticket>> ListaTickets();

        Task<Tipo> ObtenerTipoTicket(string id_tipo);

        Task<List<Departament>> ObtenerDepartamentos();
        Task<List<Prioridad>> ObtenerPrioridades();


    }
}
