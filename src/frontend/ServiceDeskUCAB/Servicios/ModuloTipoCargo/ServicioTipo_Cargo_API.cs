using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ServiceDeskUCAB.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceDeskUCAB.Servicios.ModuloTipoCargo
{
    public class ServicioTipo_Cargo_API : IServicioTipo_Cargo_API
    {
        //Declaracion de variables
        private static string _baseUrl;
        private JObject _json_respuesta;

        //Constructor
        public ServicioTipo_Cargo_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<Tipo_CargoModel> BuscarTipoCargo(Guid id)
        {

            Tipo_CargoModel tipo = new Tipo_CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync($"Tipo_Cargo/ConsultarTipo_CargoPorID/{id}");

                if (responseCargo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<Tipo_CargoModel>(stringDataRespuestaCargo);
                    tipo = resultadoCargo;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return tipo;
        }

        //Eliminar un cargo seleccionado
        public async Task<JObject> EliminarTipo_Cargo(Guid id)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await cliente.DeleteAsync($"Tipo_Cargo/EliminarTipo_Cargo/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        //Almacenar la información de un nuevo cargo
        public async Task<JObject> RegistarTipo_Cargo(Tipo_CargoModel tipo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(tipo));

            try
            {
                var response = await cliente.PostAsync("Tipo_Cargo/CrearTipoCargo/", content);
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

        //Retorna el modal de AgregarGrupo con la lista de departamentos que no están asociados
        //Retorna el modal de AgregarGrupo con la lista de departamentos que no están asociados
        public async Task<Tuple<List<CargoModel>, CargoModel, Tipo_CargoModel>> tuplaModelCargo()
        {
            Tipo_CargoModel model = new Tipo_CargoModel();
            CargoModel cargoModel = new CargoModel();
            List<CargoModel> listaCargos = new List<CargoModel>();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync("Cargo/ConsultarCargoNoAsociado");


                if (responseCargo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    //Obtengo la data del json respuesta Departamento
                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<List<CargoModel>>(stringDataRespuestaCargo);

                    listaCargos = resultadoCargo;
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
            var tupla = new Tuple<List<CargoModel>, CargoModel, Tipo_CargoModel>(listaCargos, cargoModel, model);

            return tupla;
        }

        public async Task<JObject> EditarTipo_Cargo(Tipo_CargoModel tipo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Tipo_Cargo/ActualizarTipo_Cargo", content);
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
