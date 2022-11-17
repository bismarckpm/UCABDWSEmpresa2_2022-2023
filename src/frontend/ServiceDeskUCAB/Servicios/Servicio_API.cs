using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using System.Text;

namespace ServiceDeskUCAB.Servicios
{
    public class Servicio_API : IServicio_API
    {

        public static string _baseUrl;


        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;

        }


        // Método para consumir la lista de Tipo Ticket desde el front
        public async Task<List<Tipo>> Lista()
        {
            List<Tipo> lista = new List<Tipo>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/Tipo_Ticket/Consulta");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                JObject dataRespuesta = JObject.Parse(json_respuesta);

                string stringDataRespuesta = dataRespuesta["data"].ToString();

                var resultado = JsonConvert.DeserializeObject<List<Tipo>>(stringDataRespuesta);

                lista = resultado;
            }


            return lista;
        }

        public async Task<Tipo> ObtenerTipoTicket(string id_tipo)
        {
            Tipo tipo_ticket = new Tipo();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"api/Tipo_Ticket/Consulta/{id_tipo}");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<Tipo>(json_respuesta);

                tipo_ticket = resultado;
            }
            return tipo_ticket;
        }


        // Método para consumir la lista de Ticket desde el front
        public async Task<List<Ticket>> ListaTickets()
        {
            List<Ticket> lista = new List<Ticket>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/Tickets");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                JArray dataRespuesta = JArray.Parse(json_respuesta);

                string stringDataRespuesta = dataRespuesta.ToString();

                var resultado = JsonConvert.DeserializeObject<List<Ticket>>(stringDataRespuesta);

                lista = resultado;
            }
            return lista;
        }


        //Método para Editar desde el front
        public async Task<bool> Modificar(Tipo tipo_ticket)
        {
            bool respuesta = false;


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(tipo_ticket), Encoding.UTF8, "application/json");


            var response = await cliente.PutAsync($"api/Tipo_Ticket/{tipo_ticket.Id.ToString()}", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        //Método para eliminar desde el front
        public async Task<bool> Eliminar(int idProducto)
        {
            bool respuesta = false;


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);


            var response = await cliente.DeleteAsync($"api/Tipo_Ticket/Elimina/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        //Método para Agregar Ticket desde el front
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

        //Método para Agregar Ticket desde el front
        public async Task<bool> VotarTicket(VotarTicket voto_ticket)
        {
            bool respuesta = false;


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(voto_ticket), Encoding.UTF8, "application/json");


            var response = await cliente.PutAsync($"api/Tickets/votos", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<Departament>> ObtenerDepartamentos()
        {
            var lista = new List<Departament>();
            
            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"Departamento/ConsultarDepartamento");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<List<Departament>>>(json_respuesta);

                lista = resultado.data;
            }
            return lista;
        }

        public async Task<List<Prioridad>> ObtenerPrioridades()
        {
            var lista = new List<Prioridad>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"prioridad/getprioridades");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<List<Prioridad>>>(json_respuesta);

                lista = resultado.data;
            }
            return lista;
        }


    }

}
