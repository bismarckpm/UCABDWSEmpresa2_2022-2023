
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public class ServicioUsuario_API : IServicioUsuario_API
    {
        private static string _baseUrl;
        private JObject _json_respuesta;
        public ServicioUsuario_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<JObject> Eliminar(Guid id)
        {
            HttpClient usuario = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await usuario.DeleteAsync($"api/Usuario/EliminarUsuario{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        public async Task<JObject> Guardar(Usuarios usuarios)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string json = await Task.Run(() => JsonConvert.SerializeObject(usuarios));
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(usuarios));

            try
            {
                var response = await cliente.PostAsync("api/Usuario/CrearCliente", content);
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
