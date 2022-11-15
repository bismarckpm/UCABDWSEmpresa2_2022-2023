using Newtonsoft.Json;
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

            var response = await cliente.GetAsync("Tipo_Ticket/Consulta/");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Tipo>>(json_respuesta);

                lista = resultado;
            }
            return lista;
        }

        public async Task<Tipo> ObtenerTipoTicket(string id_tipo)
        {
            Tipo tipo_ticket = new Tipo();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"Tipo_Ticket/Consulta/{id_tipo}");  //URL de Lista en el swagger

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

            var response = await cliente.GetAsync("Tickets/");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Ticket>>(json_respuesta);

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


            var response = await cliente.PutAsync($"Tipo_Ticket/{tipo_ticket.Id.ToString()}", content);

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


            var response = await cliente.DeleteAsync($"Tipo_Ticket/Eliminar/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        //Método para Agregar Ticket desde el front
        public async Task<bool> AgregarTicket(Ticket ticket)
        {
            bool respuesta = false;


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json");


            var response = await cliente.PutAsync($"Tickets", content);

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


            var response = await cliente.PutAsync($"Tickets/votos", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<Depa>> ObtenerDepartamentos()
        {
            var lista = new List<Depa>();
            
            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"Departamento/ConsultarDepartamento");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<List<Depa>>>(json_respuesta);

                lista = resultado.Data;
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

                lista = resultado.Data;
            }
            return lista;
        }


    }

}
