using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios.ModuloCargo
{
    public interface IServicioCargo_API
    {
        //Task<List<CargoDto>> ListaCargo();
        Task<Tuple<List<CargoModel>, List<Tipo_CargoModel>>> ListaCargoTipoCargo();
        Task<JObject> RegistarCargo(CargoModel cargo);
        Task<JObject> EditarCargo(CargoModel cargo);
        Task<JObject> EliminarCargo(Guid id);
        Task<CargoModel> MostrarInfoCargo(Guid id);
        Task<List<CargoModel>> CargoAsociadoTipoCargo(Guid id);
        Task<JObject> AsociarCargo(Guid id, List<string> idCargos);
        Task<List<CargoModel>> ListaCargo();
        Task<List<CargoModel>> ListaCargoNoAsociado();
        Task<JObject> EditarRelacion(Guid id, List<string> idCargos);


    }
}
