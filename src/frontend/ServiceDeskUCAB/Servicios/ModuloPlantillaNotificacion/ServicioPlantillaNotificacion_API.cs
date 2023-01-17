using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.PlantillaNotificaciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskUCAB.Servicios.ModuloPlantillaNotificacion
{
    public class ServicioPlantillaNotificacion_API : IServicioPlantillaNotificacion_API
    {
        private static string _baseUrl;
        private JObject _json_respuesta;

        // Crea una instancia de HttpClient configurada con la dirección base especificada
        private HttpClient CrearCliente()
        {
            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
            return cliente;
        }

        public ServicioPlantillaNotificacion_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<PlantillaNotificacion>> Lista()
        {
            List<PlantillaNotificacion> listaPlantilla = new();

            // Crea una instancia de HttpClient configurada
            var cliente = CrearCliente();

            try
            {
                var response = await cliente.GetAsync("PlantillaNotificacion/Consulta");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
                    listaPlantilla = resultado;
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

            return listaPlantilla;
        }

        public async Task<PlantillaNotificacion> Obtener(Guid idPlantilla)
        {
            PlantillaNotificacion plantilla = new();

            // Crea una instancia de HttpClient configurada
            var cliente = CrearCliente();
            var response = await cliente.GetAsync($"PlantillaNotificacion/Consulta/{idPlantilla}");

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(respuesta);

                if ((bool)json["success"])
                {
                    // Obtiene la data del json de respuesta
                    var stringDataRespuesta = json["data"].ToString();
                    plantilla = JsonConvert.DeserializeObject<PlantillaNotificacion>(stringDataRespuesta);
                }
            }

            return plantilla;
        }

        public async Task<JObject> Guardar(PlantillaNotificacionNueva plantilla)
        {
            // Crea una instancia de HttpClient configurada
            var cliente = CrearCliente();

            var content = new StringContent(JsonConvert.SerializeObject(plantilla), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(plantilla));

            try
            {
                var response = await cliente.PostAsync("PlantillaNotificacion/Registro/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                //return (bool)json_respuesta["success"];
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

        public async Task<JObject> Editar(PlantillaNotificacionNueva plantilla, string id)
        {
            // Crea una instancia de HttpClient configurada
            var cliente = CrearCliente();

            var content = new StringContent(JsonConvert.SerializeObject(plantilla), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync($"plantillanotificacion/actualizar/{id}", content);
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

        public async Task<JObject> Eliminar(Guid idPlantilla)
        {

            // Crea una instancia de HttpClient configurada
            var cliente = CrearCliente();

            var response = await cliente.DeleteAsync($"PlantillaNotificacion/Eliminar/{idPlantilla}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }
    }
}
