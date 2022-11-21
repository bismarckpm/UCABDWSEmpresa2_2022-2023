using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;

namespace ServicesDeskUCAB.Servicios
{
    public struct ServicioTicketAPI : IServicioTicketAPI
    {
        private static string _baseUrl;

        public ServicioTicketAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<Bitacora_Ticket> BitacoraTicket(string ticketId)
        {
            Bitacora_Ticket objeto = new Bitacora_Ticket();
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
                    var resultado = JsonConvert.DeserializeObject<Bitacora_Ticket>(stringDataRespuesta);
                    objeto = resultado;
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
            return objeto;
        }

        public async Task<bool> Editar(Ticket Objeto)
        {
            bool respuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
                var response = await cliente.PutAsync($"Ticket/Editar/", content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No edito el ticket, algo a sucedido ", e.Message);
            }
            return respuesta;
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

                    //Obtengo la data del json respuesta
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

        [HttpPost]
        public async Task<bool> Guardar(Models.Ticket Objeto)
        {
            bool respuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync($"Ticket/Guardar/", content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                    Console.WriteLine("El ticket se guarda");
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
            return respuesta;
        }


        public async Task<bool> GuardarFamilia(Familia_Ticket Objeto)
        {
            bool respuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(_baseUrl);
                var content = new StringContent(JsonConvert.SerializeObject(Objeto), Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync($"Ticket/Merge", content);
                if (response.IsSuccessStatusCode)
                {
                    respuesta = true;
                    Console.WriteLine("La familia de tickets se guarda");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception e)
            {
                Console.WriteLine("No obtiene la familai de tickets, algo a sucedido ", e.Message);
            }
            return respuesta;
        }

        public async Task<List<Ticket>> Lista(string departamentoId, string opcion)
        {
            List<Ticket> objeto = new List<Ticket>();
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
                    var resultado = JsonConvert.DeserializeObject<List<Ticket>>(stringDataRespuesta);
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

        public async Task<Ticket> Obtener(string ticketId)
        {
            Ticket objeto = new Ticket();
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
                    var resultado = JsonConvert.DeserializeObject<Ticket>(stringDataRespuesta);
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
                Console.WriteLine("No obtiene el ticket, algo a sucedido ",e.Message);
            }
            return objeto;
        }

        public Task<bool> Reenviar(Ticket padre, Ticket hijo)
        {
            throw new NotImplementedException();
        }
    }
}

