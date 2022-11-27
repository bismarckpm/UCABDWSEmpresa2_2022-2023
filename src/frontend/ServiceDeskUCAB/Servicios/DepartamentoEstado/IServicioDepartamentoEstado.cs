using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Servicios.DepartamentoEstado
{
    public interface IServicioDepartamentoEstado
    {

        Task<List<EstadoDTOUpdate>> ListaEstado(Guid Id);
        Task<ApplicationResponse<EstadoDTOUpdate>> EditarEstado(EstadoDTOUpdate estadoDTO);
        
    }
}
