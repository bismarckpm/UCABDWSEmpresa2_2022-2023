using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using System.Text.Json;

namespace ServiceDeskUCAB.Controllers
{
    public class DepartamentoYGrupoController : Controller
    {
        public async Task<IActionResult> DepartamentoGrupo()
        {

            try
            {
                List<DepartamentoDto> listDepartamentos = new List<DepartamentoDto>();
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44392/Departamento/ConsultarDepartamento");
                var _client = await client.SendAsync(request);

                List<GrupoDto> listGrupos = new List<GrupoDto>();
                HttpClient clientG = new HttpClient();
                var requestG = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44392/Grupo/ConsultarGrupo");
                var _clientG = await clientG.SendAsync(requestG);

                if (_client.IsSuccessStatusCode && _clientG.IsSuccessStatusCode)
                {
                    var responseStream = await _client.Content.ReadAsStreamAsync();
                    listDepartamentos = await JsonSerializer.DeserializeAsync<List<DepartamentoDto>>(responseStream);

                    var responseStreamG = await _clientG.Content.ReadAsStreamAsync();
                    listGrupos = await JsonSerializer.DeserializeAsync<List<GrupoDto>>(responseStreamG);
                }
                var tupla = new Tuple<List<DepartamentoDto>, List<GrupoDto>>(listDepartamentos, listGrupos);

                return View(tupla);


            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }
   
}
