using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.GrupoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloGrupo
{
    public interface IServicioGrupo_API
    {
		Task<List<GrupoModel>> ListaGrupo();
        Task<JObject> EliminarGrupo(Guid id);
        public Task<GrupoModel> BuscarGrupo(Guid id);
        public Task<JObject> RegistrarGrupo(GrupoModel grupo, List<string> idDepartamentos);
        public Task<JObject> EditarGrupo(GrupoModel grupo);
        Task<JObject> EditarRelacion(Guid id, List<string> idDepartamentos);
        Task<JObject> AsociarDepartamento(Guid id, List<string> idDepartamentos);
        Task<List<DepartamentoModel>> DepartamentoAsociadoGrupo(Guid id);
        Task<GrupoModel> BuscarNombreGrupo(string nombreGrupo);
    }
}
