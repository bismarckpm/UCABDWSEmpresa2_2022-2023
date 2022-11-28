using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios;
using System.Xml.Linq;

namespace ServiceDeskUCAB.Servicios
{
    public class ServicioPrioridadAPI : IServicioPrioridadAPI
    {
        private static string _baseUrl;

        public ServicioPrioridadAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Prioridad>> Lista()
        {
            List<Prioridad> lista = new();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            Console.WriteLine(_baseUrl);

            try
            {
                var response = await cliente.GetAsync("Prioridad/Lista");
                if (response.IsSuccessStatusCode)
                {

                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<Prioridad>>(stringDataRespuesta);

                    lista = resultado;
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

            return lista;
        }

        public async Task<List<Prioridad>> ListaHabilitado()
        {
            List<Models.Prioridad> lista = new List<Prioridad>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Prioridad/Habilitados");

                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<List<Prioridad>>(json_respuesta);
                    lista = resultado;
                }
            }
            catch (Exception e)
            {

            }
            return lista;
        }

        public async Task<Prioridad> Obtener(Guid PrioridadID)
        {
            Prioridad objeto = new Prioridad();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Prioridad/Obtener/{PrioridadID}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Es success obtener");
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<Prioridad>(stringDataRespuesta);
                    objeto = resultado;
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("no entra");
            }
            return objeto;
        }

        public async Task<JObject> Guardar(Prioridad Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PostAsync($"Prioridad/Guardar/", content);
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
            return null;
        }

        public async Task<JObject> Editar(Prioridad Objeto)
        {
            JObject _json_respuesta = new JObject();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            Console.WriteLine(content.ToString());
            try
            {
                var response = await cliente.PutAsync($"Prioridad/Editar/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                _json_respuesta = JObject.Parse(respuesta);
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
