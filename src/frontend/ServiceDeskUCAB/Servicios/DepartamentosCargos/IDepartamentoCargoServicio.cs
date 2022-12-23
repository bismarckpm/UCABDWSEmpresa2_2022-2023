using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Models.Response;
using ServicesDeskUCAB.Models.DTO.CargoDTO;

namespace ServiceDeskUCAB.Servicios.DepartamentosCargos
{
    public interface IDepartamentoCargoServicio
    {
        Task<List<CargoDTOUpdate>> ListaCargo(Guid Id);
        Task<ApplicationResponse<CargoDTOUpdate>> EditarCargo(CargoDTOUpdate estadoDTO);

        Task<ApplicationResponse<CargoDTOUpdate>> DeshabilitarCargo(Guid Id);

        Task<ApplicationResponse<CargoDTOUpdate>> HabilitarCargo(Guid Id);
        Task<ApplicationResponse<CargoDTOCreate>> RegistrarCargo(CargoDTOCreate cargoDTOCreate);
    }
}
