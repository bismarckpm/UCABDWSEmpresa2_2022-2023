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
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;

namespace ServicesDeskUCAB.Servicios
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

        public async Task<List<Models.Prioridad>> ListaEstado(string Estado)
        {
            List<Models.Prioridad> lista = new List<Prioridad>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Prioridad/Lista/{Estado}");

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

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<Prioridad>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
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

        public async Task<bool> Guardar(Prioridad Objeto)
        {
            bool respuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync($"Prioridad/Guardar/", content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                }
            }
            catch (Exception e)
            {

            }
            return respuesta;
        }

        public async Task<bool> Editar(Models.Prioridad Objeto)
        {
            bool respuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
                var response = await cliente.PutAsync($"Prioridad/Editar/", content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                }
            }
            catch (Exception e)
            {

            }
            return respuesta;
        }
    }
}
