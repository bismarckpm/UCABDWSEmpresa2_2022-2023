using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Models.ViewModel
{
    public class TipoNuevoViewModel
    {
        public List<Tipo> ListaTipo { get; set; }

        public Tipo tipo { get; set; }
        public List<TipoCargoNuevo> tipoCargoNuevo { get; set; }

        public List<Departament> ListaDepartamento { get; set; }

        public List<CargoDTOUpdate> ListaCargos { get; set; }

        public Tipo tipoActualizar { get; set; }

        public string idDepartamento { get; set; }

        public List<Modelo_Aprobacion> listaModelos { get; set; }

    }
}
