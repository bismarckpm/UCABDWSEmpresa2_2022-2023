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


        public async Task<IActionResult> RegistrarDepartamento(DepartamentoDto dept)
        {
            try
            {
                HttpClient client = new HttpClient();
                var _client = await client.PostAsJsonAsync<DepartamentoDto>("https://localhost:44392/Departamento/CrearDepartamento", dept);
                return RedirectToAction("DepartamentoGrupo");
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public IActionResult AgregarDepartamento()
        {
            try
            {
                return PartialView();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public IActionResult VentanaEliminarDepartamento(Guid id)
        {
            try
            {
                return PartialView(id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> EliminarDepartamento(Guid id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var _client = await client.DeleteAsync("https://localhost:44392/Departamento/EliminarDepartamento/" + id.ToString());
                return RedirectToAction("DepartamentoGrupo");
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> VentanaEditarDepartamento(Guid id)
        {
            try
            {
                DepartamentoModel departamento = new DepartamentoModel();
                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44392/Departamento/ConsultarDepartamentoPorID/" + id.ToString());
                var _client = await client.SendAsync(request);
                if (_client.IsSuccessStatusCode)
                {
                    var responseStream = await _client.Content.ReadAsStreamAsync();
                    departamento = await JsonSerializer.DeserializeAsync<DepartamentoModel>(responseStream);
                }
                return PartialView(departamento);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> EditarDepartamento(DepartamentoDto_Update departamento)
        {
            try
            {
                HttpClient client = new HttpClient();
                var _client = await client.PutAsJsonAsync("https://localhost:44392/Departamento/ActualizarDepartamento", departamento);
                return RedirectToAction("DepartamentoGrupo");
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
    }

}