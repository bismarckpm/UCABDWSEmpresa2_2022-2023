using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloCargo
{
    public interface IServicioCargo_API
    {
        //Task<List<CargoDto>> ListaCargo();
        Task<Tuple<List<CargoDto>, List<Tipo_CargoDto>>> ListaCargoTipoCargo();
        Task<JObject> RegistarCargo(CargoDto cargo);
        Task<JObject> EditarCargo(CargoDto_Update cargo);
        Task<JObject> EliminarCargo(Guid id);
        Task<CargoModel> MostrarInfoCargo(Guid id);
        Task<List<CargoModel>> CargoAsociadoTipoCargo(Guid id);
        Task<JObject> AsociarCargo(Guid id, List<string> idCargos);
        Task<List<CargoModel>> ListaCargo();
        Task<List<CargoModel>> ListaCargoNoAsociado();
        Task<JObject> EditarRelacion(Guid id, List<string> idCargos);


    }
}
