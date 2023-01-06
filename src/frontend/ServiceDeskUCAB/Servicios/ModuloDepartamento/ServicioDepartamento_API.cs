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
        /// <summary>
        /// Declaración de variables.
        /// </summary>
        
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Inicialización de variables.
        /// </summary>
        /// <param name="_httpClientFactory">Objeto de la interfaz IHttpClientFactory.</param>
        
        public ServicioDepartamento_API(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }

        /// <summary>
        /// Método para realizar una petición Http para eliminar de forma lógica un departamento y quitar su relaciones.
        /// </summary>
        /// <param name="id">Identificador de un departamento.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
        public async Task<JObject> EliminarDepartamento(Guid id)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");
            var response = await cliente.DeleteAsync($"Departamento/EliminarDepartamento/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        /// <summary>
        /// Método que realiza un petición Http para almacenar la información de un departamento.
        /// </summary>
        /// <param name="departamento">Objeto de tipo DepartamentoModel, contiene atributos de un nuevo departamento.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
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

        /// <summary>
        /// Método que realiza un petición Http para mostrar la información de un departamento segun su id.
        /// </summary>
        /// <param name="id">Identificador de Departamento.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
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

        /// <summary>
        /// Método que realiza un petición Http para modificar los atributos (nombre y descripción) de un departamento,
        /// que han sido alterados.
        /// </summary>
        /// <param name="dept">Objeto del tipo DepartamentoModel, contiene nombre y descripción de un departamento.</param>
        /// <returns>Devuelve un objeto del tipo Json.</returns>

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

        /// <summary>
        /// Método que realiza un petición Http para extraer departamentos activos.
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo DepartamentoModel.</returns>
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

        /// <summary>
        /// Método que realiza un petición Http para extraer departamentos no asociados a un grupo.
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo DepartamentoModel.</returns>
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
