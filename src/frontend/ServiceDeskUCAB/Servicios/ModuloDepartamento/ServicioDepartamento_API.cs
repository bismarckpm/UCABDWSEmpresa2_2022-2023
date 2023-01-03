using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ServiceDeskUCAB.Servicios.ModuloDepartamento
{
    public class ServicioDepartamento_API : IServicioDepartamento_API
    {
        //Declaracion de variables
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        //Constructor
        public ServicioDepartamento_API(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        //Eliminar un departamento seleccionado
        public async Task<JObject> EliminarDepartamento(Guid id)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");
            var response = await cliente.DeleteAsync($"Departamento/EliminarDepartamento/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        //Almacenar la información de un nuevo departamento
        public async Task<JObject> RegistrarDepartamento(DepartamentoModel departamento)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            var content = new StringContent(JsonConvert.SerializeObject(departamento), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(departamento));

            try
            {
                var response = await cliente.PostAsync("Departamento/CrearDepartamento/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);

                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        //Modificar los campos de un departamento
        public async Task<DepartamentoModel> MostrarInfoDepartamento(Guid id)
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync($"Departamento/ConsultarDepartamentoPorID/{id}");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<DepartamentoModel>(stringDataRespuestaDept);
                    departamento = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return departamento;
        }

        public async Task<JObject> EditarDepartamento(DepartamentoModel dept)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            var content = new StringContent(JsonConvert.SerializeObject(dept), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Departamento/ActualizarDepartamento", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        public async Task<List<DepartamentoModel>> ListaDepartamento()
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync("Departamento/ConsultarDepartamentoNoEliminado/");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<List<DepartamentoModel>>(stringDataRespuestaDept);
                    departamento.departamentos = resultadoDept;
                }
            }
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			return departamento.departamentos;
        }

        public async Task<List<DepartamentoModel>> ListaDepartamentoNoAsociado()
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync("Departamento/ConsultarDepartamentoNoAsociado/");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<List<DepartamentoModel>>(stringDataRespuestaDept);
                    departamento.departamentos = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return departamento.departamentos;
        }

    }
}
