using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.GrupoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloGrupo
{
    public interface IServicioGrupo_API
    {
        public Task<Tuple<List<DepartamentoModel>, DepartamentoModel, GrupoModel>> tuplaModelDepartamento();
		Task<JObject> EliminarGrupo(Guid id);
		public Task<GrupoModel> BuscarGrupo(Guid id);
		public Task<JObject> RegistrarGrupo(GrupoModel grupo);
		public Task<JObject> EditarGrupo(GrupoModel grupo);
	}
}
