using ServicesDeskUCABWS.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public class ServicioUsuario_API : IServicioUsuario_API
    {
        private static string _baseUrl;
        private JObject _json_respuesta;
        public ServicioUsuario_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<List<Usuarios>> Lista()
        {
            List<Usuarios> listaUsuarios = new();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var response = await cliente.GetAsync("api/Usuario");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<Usuarios>>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
                    listaUsuarios = resultado;
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

            return listaUsuarios;
        }
    }
}
