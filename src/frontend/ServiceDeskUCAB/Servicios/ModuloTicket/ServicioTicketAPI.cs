using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
	public class ServicioTicketAPI : IServicioTicketAPI
	{
        private static string _baseUrl;

        public ServicioTicketAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<TicketCompletoDTO> Obtener(string ticketId)
        {
            TicketCompletoDTO objeto = new TicketCompletoDTO();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Ticket/Obtener/{ticketId}");
                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<TicketCompletoDTO>(stringDataRespuesta);
                    objeto = resultado;
                    Console.WriteLine("Obtiene el ticket");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene el ticket, algo a sucedido ", e.Message);
            }
            return objeto;
        }

        public async Task<List<Ticket>> FamiliaTicket(string ticketId)
        {
            List<Ticket> objeto = new List<Ticket>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Ticket/Familia/{ticketId}");
                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<Ticket>>(stringDataRespuesta);
                    objeto = resultado;
                    Console.WriteLine("Obtiene la familia del ticket");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene la familia del ticket, algo a sucedido ", e.Message);
            }
            return objeto;
        }

        public async Task<List<BitacoraDTO>> BitacoraTicket(string ticketId)
        {
            List<BitacoraDTO> lista = new List<BitacoraDTO>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Ticket/Bitacora/{ticketId}");
                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<BitacoraDTO>>(stringDataRespuesta);
                    lista = resultado;
                    Console.WriteLine("Obtiene la bitacora del ticket");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene la bitacora del ticket, algo a sucedido ", e.Message);
            }
            return lista;
        }

        public async Task<List<TicketBasicoDTO>> Lista(string departamentoId, string opcion) 
        {
            List<TicketBasicoDTO> objeto = new List<TicketBasicoDTO>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var response = await cliente.GetAsync($"Ticket/Lista/{departamentoId}/{opcion}");
                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<TicketBasicoDTO>>(stringDataRespuesta);
                    objeto = resultado;
                    Console.WriteLine("Obtiene los tickets");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return objeto;
        }

        [HttpPost]
        public async Task<JObject> Guardar(TicketDTO Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PostAsync($"Ticket/Guardar/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return null;
        }

        [HttpPost]
        public async Task<JObject> GuardarReenviar(TicketReenviarDTO Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PostAsync($"Ticket/Reenviar/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return null;
        }

        [HttpPost]
        public async Task<JObject> GuardarMerge(FamiliaMergeDTO Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PostAsync($"Ticket/Merge/", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return null;
        }
        public async Task<JObject> Cancelar(string Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PutAsync($"Ticket/Cancelar/{Objeto}", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return null;
        }
        public async Task<JObject> CambiarEstado(string Objeto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PutAsync($"Ticket/CambiarEstado/{Objeto}", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene los tickets, algo a sucedido ", e.Message);
            }
            return null;
        }

    }
}


