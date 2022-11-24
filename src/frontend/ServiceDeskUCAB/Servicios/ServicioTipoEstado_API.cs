using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.EstadoTicket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskUCAB.Servicios
{
    public class ServicioTipoEstado_API : IServicioTipoEstado_API
    {
        private static string _baseUrl;
        private JObject _json_respuesta;
        public ServicioTipoEstado_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<TipoEstado>> Lista()
        {
            List<TipoEstado> listaTipoEstado = new();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var response = await cliente.GetAsync("TipoEstado/Consulta");
                if (response.IsSuccessStatusCode)
                {

                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<TipoEstado>>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
                    listaTipoEstado = resultado;
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

            return listaTipoEstado;
        }
        public async Task<List<Etiqueta>> ListaEtiqueta()
        {
            List<Etiqueta> listaEtiqueta = new();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var response = await cliente.GetAsync("Etiqueta/Consulta");
                if (response.IsSuccessStatusCode)
                {

                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<Etiqueta>>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
                    listaEtiqueta = resultado;
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

            return listaEtiqueta;
        }
        public async Task<JObject> Guardar(TipoEstadoNuevo tipoEstadoNuevo)
        {

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(tipoEstadoNuevo), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(tipoEstadoNuevo));

            try
            {
                var response = await cliente.PostAsync("TipoEstado/Registro", content);
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
        public async Task<JObject> Eliminar(Guid idEstado)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await cliente.DeleteAsync($"TipoEstado/Eliminar/{idEstado}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        public async Task<TipoEstado> Obtener(Guid idEstado)
        {
            TipoEstado tipoEstado = new();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var response = await cliente.GetAsync($"TipoEstado/Consulta/{idEstado}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            if ((bool)json_respuesta["success"])
            {
                //Obtengo la data del json respuesta
                string stringDataRespuesta = json_respuesta["data"].ToString();

                var resultado = JsonConvert.DeserializeObject<TipoEstado>(stringDataRespuesta);
                tipoEstado = resultado;
            }

            return tipoEstado;
        }
        public async Task<JObject> Editar(TipoEstadoNuevo estado, string id)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(estado), Encoding.UTF8, "application/json");


            try
            {
                var response = await cliente.PutAsync($"TipoEstado/Actualizar/{id}", content);
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
