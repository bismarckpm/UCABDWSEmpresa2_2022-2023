using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;

namespace ServiceDeskUCAB.ViewModel.CargoDepartamento
{
    public class ViewModelCargoDepartamento
    {
        public List<CargoDTOUpdate>? ListaCargos { get; set; }
        public DepartamentoSearchDTO? Departamento { get; set; }
        public string? Message { get; set; }
    }
}
