using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;

namespace ServiceDeskUCAB.Servicios.ModuloDepartamento
{
    public interface IServicioDepartamento_API
    {
        Task<Tuple<List<DepartamentoDto>, List<GrupoDto>>> ListaDepartamentoGrupo();
        Task<JObject> RegistrarDepartamento(DepartamentoDto dept);
        Task<JObject> EditarDepartamento(DepartamentoDto_Update dept);
        Task<JObject> EliminarDepartamento(Guid id);
        Task<DepartamentoModel> MostrarInfoDepartamento(Guid id);
		Task<List<DepartamentoModel>> DepartamentoAsociadoGrupo(Guid id);
        Task<JObject> AsociarDepartamento(List<string> idDepartamento);
        Task<List<DepartamentoModel>> ListaDepartamento();

	}
}