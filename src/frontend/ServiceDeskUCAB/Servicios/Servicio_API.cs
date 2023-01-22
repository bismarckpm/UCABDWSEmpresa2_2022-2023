using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ServiceDeskUCAB.Servicios
{
    public class Servicio_API : IServicio_API
    {

        public static string _baseUrl;


        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;


        }

        private async Task<T> GetAsyncFromServer<T>(string Url)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync(Url);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                JObject dataRespuesta = JObject.Parse(json_respuesta);
                string stringDataRespuesta = dataRespuesta.ToString();
                return JsonConvert.DeserializeObject<T>(stringDataRespuesta); 
            }
            throw new Exception("Error de conexion con el servidor");
            //return default(T);
        }

        private async Task<T> PutAsyncFromServer<T>(string Url, StringContent content)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.PutAsync(Url, content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                JObject dataRespuesta = JObject.Parse(json_respuesta);
                string stringDataRespuesta = dataRespuesta.ToString();
                return JsonConvert.DeserializeObject<T>(stringDataRespuesta);
            }
            throw new Exception("Error de conexion con el servidor");
        }

        private async Task<T> PostAsyncFromServer<T>(string Url, StringContent content)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.PostAsync(Url, content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                JObject dataRespuesta = JObject.Parse(json_respuesta);
                string stringDataRespuesta = dataRespuesta.ToString();
                return JsonConvert.DeserializeObject<T>(stringDataRespuesta);
            }
            throw new Exception("Error de conexion con el servidor");
        }

        private async Task<bool> DeleteAsyncFromServer(string Url)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync(Url);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        // Método para consumir la lista de Tipo Ticket desde el front
        public async Task<List<Tipo>> Lista()
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Tipo>>>("api/Tipo_Ticket/Consulta/");
            
            return result.Data;
        }

        public async Task<List<Tipo>> ListaxDepartamento(Guid id)
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Tipo>>>("api/Tipo_Ticket/ConsultaxDepartamento/" + id);
            
            return result.Data;
        }

        public async Task<List<Votos_Ticket>> ObtenerVotos(string idUsuario)
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Votos_Ticket>>>($"api/Votos_Ticket/Consulta/" + idUsuario);
            
            return result.Data;

        }

        public async Task<List<Departament>> ListaDepa()
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Departament>>>("Departamento/ConsultarDepartamento/");
            
            return result.Data;
        }

        public async Task<List<CargoDTOUpdate>> ListaCargos(Guid IdDepartamento)
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<CargoDTOUpdate>>>("Cargo/ConsultarCargoPorDepartamento/" + IdDepartamento);
            
            return result.Data;
        }

        //Método para Agregar Ticket desde el front
        public async Task<ApplicationResponse<Votos_Ticket>> VotarTicket(VotarTicket voto_ticket)
        {
            var contentstring = new StringContent(JsonConvert.SerializeObject(voto_ticket), Encoding.UTF8, "application/json");
            return await PutAsyncFromServer<ApplicationResponse<Votos_Ticket>>($"api/Tickets/votos", contentstring);
            
        }

        public async Task<ApplicationResponse<Tipo_TicketDTOCreate>> Guardar(Tipo_TicketDTOCreate tipo)
        {
            if (tipo.Departamento.Count() == 0) { tipo.Departamento = null; };

            if (tipo.Flujo_Aprobacion.Count() == 0) { tipo.Flujo_Aprobacion = null; };


            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");

            return await PostAsyncFromServer<ApplicationResponse<Tipo_TicketDTOCreate>>("api/Tipo_Ticket/Guardar/", content);

        }



        //Método para eliminar desde el front
        public async Task<bool> Eliminar(Guid id)
        {
            return await DeleteAsyncFromServer($"api/Tipo_Ticket/Elimina/(\"{id}\")");
            
        }

        public async Task<ApplicationResponse<Ticket>> ObtenerTicket(string id)
        {
            try
            {
                return await GetAsyncFromServer<ApplicationResponse<Ticket>>($"api/Tickets/{id}");
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<Ticket>() { Success = false , Message= ex.Message};
            }
        }

        public async Task<ApplicationResponse<Tipo_TicketDTOUpdate>> Actualizar(Tipo_TicketDTOUpdate tipo)
        {
            var contentstring = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");
            return await PutAsyncFromServer<ApplicationResponse<Tipo_TicketDTOUpdate>>("api/Tipo_Ticket/Editar/" + tipo.Id, contentstring);
            
        }

        public async Task<List<Votos_Ticket>> ObtenerVotosNoPendientes(string idUsuario)
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Votos_Ticket>>>($"api/Votos_Ticket/ConsultaNP/" + idUsuario);
            return result.Data;
        }

        public async Task<List<Modelo_Aprobacion>> ObtenerListaModelosAprobacion()
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Modelo_Aprobacion>>>("api/Tipo_Ticket/ObtenerTipoFlujos");
            return result.Data;
        }

        public async Task<List<Prioridad>> ObtenerPrioridades()
        {
            var result = await GetAsyncFromServer<ApplicationResponse<List<Prioridad>>>($"prioridad/getprioridades");
            return result.Data;
        }

        public async Task<bool> AgregarTicket(NuevoTicket ticket)
        {
            bool respuesta = false;
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(ticket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Tickets", content);
            var res = await response.Content.ReadAsStringAsync();
            JObject _json_respuesta = JObject.Parse(res);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        
    }

}
