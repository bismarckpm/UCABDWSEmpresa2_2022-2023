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
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync("Priridad/Lista");
            
                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<GenericResponse>(json_respuesta);
                    lista = resultado.Data;
                }
            }
            catch(Exception e)
            {

            }
            return lista;
        }

        public async Task<List<Models.Prioridad>> ListaEstado(string Estado)
        {
            List<Models.Prioridad> lista = new List<Models.Prioridad>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Priridad/Lista/{Estado}");

                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<GenericResponse>(json_respuesta);
                    lista = resultado.Data;
                }
            }
            catch (Exception e)
            {

            }
            return lista;
        }

        public async Task<Models.Prioridad> Obtener(int PrioridadID)
        {
            Models.Prioridad objeto = new Models.Prioridad();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Priridad/{PrioridadID}");
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject json_respuesta = JObject.Parse(respuesta);
                if (response.IsSuccessStatusCode)
                {
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<Models.Prioridad>(stringDataRespuesta);
                    objeto = resultado;
                }
            }
            catch(Exception e)
            {

            }
            return objeto;
        }

        public async Task<bool> Guardar(Models.Prioridad Objeto)
        {
            bool respuesta = false; 
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto) , Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync($"Priridad/Guardar/",content);
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
                var response = await cliente.PutAsync($"Priridad/Editar/", content);
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

