using ServiceDeskUCAB.Models.EstadoTicket;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;

namespace ServiceDeskUCAB.ViewModel.EstadoDepartamento
{
    public class ViewModelEstadoDepartamento
    {
        public List<EstadoDTOUpdate>? ListaEstado { get; set; }
        public DepartamentoSearchDTO? Departamento { get; set; }  
        public string? Message { get; set; }
    }
}
