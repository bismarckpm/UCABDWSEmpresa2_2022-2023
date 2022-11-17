using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloGrupo
{
    public interface IServicioGrupo_API
    {
		Task<Tuple<DepartamentoModel, GrupoModel>> tuplaModelDepartamento();
		public  Task<JObject> GuardarGrupo(GrupoDto grupo, List<DepartamentoDto> listaDept);
		Task<JObject> EliminarGrupo(Guid id);
		public Task<GrupoModel> BuscarGrupo(Guid id);
	}
}
