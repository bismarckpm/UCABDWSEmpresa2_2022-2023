using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using ServicesDeskUCAB.Servicios.Prioridad;
using System.Net.Http;
using ServicesDeskUCAB.Models;
using Newtonsoft.Json.Linq;

namespace ServicesDeskUCAB.Servicios.Prioridad
{
    public class ServicioAPI : IServicioAPI
    {
        private static string _baseUrl;

        public ServicioAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection ("ApiSetting:baseUrl").Value;
        }

        public async Task<List<Models.Prioridad>> Lista()
        {
            List<Models.Prioridad> lista = new List<Models.Prioridad>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Priridad/Lista");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<GenericResponse>(json_respuesta);
                lista = resultado.Data;
            }
            return lista;
        }

        public async Task<Models.Prioridad> Obtener(int PrioridadID)
        {
            Models.Prioridad objeto = new Models.Prioridad();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Priridad/{PrioridadID}");
            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);
            if ((bool)json_respuesta["success"])
            {
                //Obtengo la data del json respuesta
                string stringDataRespuesta = json_respuesta["data"].ToString();

                var resultado = JsonConvert.DeserializeObject<Models.Prioridad>(stringDataRespuesta);
                objeto = resultado;
            }

            return objeto;
        }

        public async Task<JObject> Guardar(Models.Prioridad Prioridad)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Prioridad), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(Prioridad));

            try
            {
                var response = await cliente.PostAsync("Prioridad/Guardar/", content);
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
        }

        public async Task<Models.Prioridad> Editar(Models.Prioridad prioridad,int PrioridadID)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(prioridad), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(prioridad));

            try
            {
                var response = await cliente.PutAsync($"Prioridad/Actualizar/{id}", content);
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

