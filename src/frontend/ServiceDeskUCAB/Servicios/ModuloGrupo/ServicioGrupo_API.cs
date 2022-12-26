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
        //Declaracion de variables
        private static string _baseUrl;
        private JObject _json_respuesta;

        //Constructor
        public ServicioGrupo_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

		//Carga la lista de grupos
		public async Task<List<GrupoModel>> ListaGrupo()
		{
			List<GrupoModel> listaGrupo = new List<GrupoModel>();

			var cliente = new HttpClient
			{
				BaseAddress = new Uri(_baseUrl)
			};

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

		public async Task<GrupoModel> BuscarGrupo(Guid id)
        {

            GrupoModel grupo = new GrupoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

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

        public async Task<JObject> EliminarGrupo(Guid id)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await cliente.DeleteAsync($"Grupo/EliminarGrupo/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        //Retorna el modal de AgregarGrupo con la lista de departamentos que no están asociados
        public async Task<Tuple<List<DepartamentoModel>, DepartamentoModel, GrupoModel>> tuplaModelDepartamento()
        {
            GrupoModel model = new GrupoModel();
            DepartamentoModel departamentoModel = new DepartamentoModel();
            List<DepartamentoModel> listaDepartamentos = new List<DepartamentoModel>();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseDept = await cliente.GetAsync("Departamento/ConsultarDepartamentoNoAsociado");


                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    //Obtengo la data del json respuesta Departamento
                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<List<DepartamentoModel>>(stringDataRespuestaDept);

                    listaDepartamentos = resultadoDept;
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
            var tupla = new Tuple<List<DepartamentoModel>, DepartamentoModel, GrupoModel>(listaDepartamentos, departamentoModel, model);

            return tupla;
        }

        //Almacenar la información de un nuevo grupo
        public async Task<JObject> RegistrarGrupo(GrupoModel grupo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

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

        public async Task<JObject> EditarGrupo(GrupoModel grupo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

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
    }
}
