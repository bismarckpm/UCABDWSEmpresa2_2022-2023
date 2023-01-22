using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using System.Runtime.CompilerServices;

namespace ServiceDeskUCAB.Servicios.ModuloGrupo
{
    public class ServicioGrupo_API : IServicioGrupo_API
    {
        /// <summary>
        /// Declaración de variables.
        /// </summary>
        
        private JObject _json_respuesta;
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Inicialización de variables.
        /// </summary>
        /// <param name="httpClientFactory">Objeto de la interfaz IHttpClientFactory.</param>
        
        public ServicioGrupo_API(IHttpClientFactory httpClientFactory) 
        {
            this._httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Método que realiza un petición Http para extraer grupos activos.
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo GrupoModel.</returns>
		public async Task<List<GrupoModel>> ListaGrupo()
		{
			List<GrupoModel> listaGrupo = new List<GrupoModel>();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
			{
				var responseGrupo = await cliente.GetAsync("Grupo/ConsultarGrupoNoEliminado/");

				if (responseGrupo.IsSuccessStatusCode)
				{
					var respuestaGrupo = await responseGrupo.Content.ReadAsStringAsync();
					JObject json_respuestaGrupo = JObject.Parse(respuestaGrupo);


					//Obtengo la data del json respuesta Grupo
					string stringDataRespuestaGrupo = json_respuestaGrupo["data"].ToString();
					var resultadoGrupo = JsonConvert.DeserializeObject<List<GrupoModel>>(stringDataRespuestaGrupo);

					listaGrupo = resultadoGrupo;
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

			return listaGrupo;
		}

        /// <summary>
        /// Método que realiza un petición Http para extraer los atributos de un grupo.
        /// </summary>
        /// <param name="id">Identificardor de un grupo.</param>
        /// <returns>Devuelve un objeto del tipo GrupoModel.</returns>
		public async Task<GrupoModel> BuscarGrupo(Guid id)
        {

            GrupoModel grupo = new GrupoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync($"Grupo/ConsultarGrupoPorID/{id}");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<GrupoModel>(stringDataRespuestaDept);
                    grupo = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return grupo;
        }

        /// <summary>
        /// Método para realizar una petición Http para eliminar de forma lógica un grupo y quitar su relaciones.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
        public async Task<JObject> EliminarGrupo(Guid id)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");
            var response = await cliente.DeleteAsync($"Grupo/EliminarGrupo/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        /// <summary>
        /// Método que realiza un petición Http para almacenar la información de un grupo y asociar los departamentos.
        /// </summary>
        /// <param name="grupo">Objeto de tipo GrupoModel, contiene atributos de un nuevo grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
        public async Task<JObject> RegistrarGrupo(GrupoModel grupo, List <string> idDepartamentos)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            var content = new StringContent(JsonConvert.SerializeObject(grupo), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(grupo));

            try
            {
                var response = await cliente.PostAsync("Grupo/CrearGrupo/", content);
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
        /// Método que realiza un petición Http para modificar los atributos (nombre y descripción) de un grupo,
        /// que han sido alterados.
        /// </summary>
        /// <param name="grupo">Objeto del tipo GrupoModel, contiene nombre y descripción de un grupo.</param>
        /// <returns>Devuelve un objeto del tipo Json.</returns>
        public async Task<JObject> EditarGrupo(GrupoModel grupo)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            var content = new StringContent(JsonConvert.SerializeObject(grupo), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Grupo/ActualizarGrupo", content);
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
        /// Método que realiza un petición Http para asociar departamentos a un grupo.
        /// Modificando la columna id_grupo de la tabla departamento.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de los departamentos.</param>
        /// <returns>Devuelve un objeto de tipo Json.</returns>
        public async Task<JObject> AsociarDepartamento(Guid id, List<string> idDepartamentos)
        {
            GrupoModel model = new GrupoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            string combinedString = string.Join(",", idDepartamentos);
            var contentDept = new StringContent(JsonConvert.SerializeObject(combinedString), Encoding.UTF8, "application/json");

            try
            {
                var responseDepartamento = await cliente.PutAsync($"Grupo/AsignarGrupoToDepartamento/{id}", contentDept);
                var respuestaDepartamento = await responseDepartamento.Content.ReadAsStringAsync();
                JObject json_respuesta = JObject.Parse(respuestaDepartamento);
                return json_respuesta;

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
        /// Método que realiza una petición Http para modificar (agregar o eliminar)
        /// la columna id_grupo de la tabla departamento.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de los departamentos.</param>
        /// <returns>Devuelve objeto de tipo Json.</returns>
        public async Task<JObject> EditarRelacion(Guid id, List<string> idDepartamentos)
        {
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            string combinedString = string.Join(",", idDepartamentos);
            var content = new StringContent(JsonConvert.SerializeObject(combinedString), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync($"Grupo/EditarRelacion/{id}", content);
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
        /// Método que realiza un petición Http para consultar los departamentos asociados a un grupo.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <returns>Devuelve un lista de objetos de tipo DepartamentoModel.</returns>
        public async Task<List<DepartamentoModel>> DepartamentoAsociadoGrupo(Guid id)
        {
            DepartamentoModel departamento = new DepartamentoModel();

            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync($"Grupo/ConsultarDepartamentosPorIdGrupo/{id}");

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
        
        /// <summary>
        /// Método que realiza una petición Http para consultar por el nombre de un grupo.
        /// </summary>
        /// <param name="nombreGrupo">Variable de tipo string que contiene el nombre de un grupo.</param>
        /// <returns>Devuelve un objeto del tipo GrupoModel, contiene un grupo con todos sus atributos.</returns>
        public async Task<GrupoModel> BuscarNombreGrupo(string nombreGrupo)
        {
            GrupoModel grupo = new GrupoModel();
            var cliente = _httpClientFactory.CreateClient("ConnectionApi");

            try
            {
                var responseDept = await cliente.GetAsync($"Grupo/ConsultarPorNombreGrupo/{nombreGrupo}");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<GrupoModel>(stringDataRespuestaDept);
                    grupo = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return grupo;
        }
    }
}
