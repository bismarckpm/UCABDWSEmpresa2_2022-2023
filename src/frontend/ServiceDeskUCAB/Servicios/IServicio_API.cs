using ServiceDeskUCAB.Models;
using ServicesDeskUCAB.Models.TipoTicketModels;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();

        Task<bool> Guardar(Tipo_TicketDTOCreate tipo);

       
        Task<bool> Eliminar(Guid id);

        Task<List<Departament>> ListaDepa();

        Task<List<TipoCargo>> ListaCargos();
    }
}
