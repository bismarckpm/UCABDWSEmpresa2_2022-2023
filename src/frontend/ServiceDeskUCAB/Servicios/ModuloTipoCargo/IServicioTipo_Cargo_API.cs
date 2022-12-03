using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;



namespace ServiceDeskUCAB.Servicios.ModuloTipoCargo
{
    public interface IServicioTipo_Cargo_API
    {
        public Task<Tuple<List<CargoModel>, CargoModel, Tipo_CargoModel>> tuplaModelCargo();
        public Task<JObject> RegistarTipo_Cargo(Tipo_CargoModel tipo);
       /// Task<JObject> EditarTipo_Cargo(Tipo_CargoDto_Update tipo);
        public Task<JObject> EliminarTipo_Cargo(Guid id);
       // Task<CargoModel> MostrarInfoTipo_Cargo(Guid id);
        public Task<Tipo_CargoModel> BuscarTipoCargo(Guid id);

        public Task<JObject> EditarTipo_Cargo(Tipo_CargoModel tipo);

        

    }
}
