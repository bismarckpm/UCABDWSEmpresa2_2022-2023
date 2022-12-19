using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel.CargoTipoCargo
{
    public class TipoCargoEditarViewModel
    {
        public List<CargoModel> cargoAsociado { get; set; }
        public  List<CargoModel> cargo { get; set; }
        public  Tipo_CargoModel tipo { get; set; }

    }
}
