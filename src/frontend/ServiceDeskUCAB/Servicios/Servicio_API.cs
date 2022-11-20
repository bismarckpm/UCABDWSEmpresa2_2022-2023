using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
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

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;


        }

        // Método para consumir la lista de Tipo Ticket desde el front
        public async Task<List<Tipo>> Lista()
        {
            List<Tipo> lista = new List<Tipo>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/Tipo_Ticket/Consulta/");  //URL de Lista en el swagger

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

        public async Task<List<Departament>> ListaDepa()
        {
            List<Departament> lista = new List<Departament>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("Departamento/ConsultarDepartamento/");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();


                var resultado = JsonConvert.DeserializeObject<List<Departament>>(json_respuesta);

                lista = resultado;
            }


            return lista;
        }

        public async Task<List<TipoCargo>> ListaCargos()
        {
            List<TipoCargo> lista = new List<TipoCargo>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("Cargo/ConsultarCargos/");  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();


                var resultado = JsonConvert.DeserializeObject<List<TipoCargo>>(json_respuesta);

                lista = resultado;
            }


            return lista;
        }
        public async Task<ApplicationResponse<Tipo_TicketDTOCreate>> Guardar(Tipo_TicketDTOCreate tipo)
        {
            bool respuesta = false;

        
                if (tipo.tipo == "Modelo_No_Aprobacion")
                {
                tipo.flujo_Aprobacion = null;

                }


            

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(tipo));
            

            var response = await cliente.PostAsync("api/Tipo_Ticket/Guardar/", content);
            
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                Console.WriteLine(JsonConvert.SerializeObject(json_respuesta));
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<Tipo_TicketDTOCreate>>(json_respuesta);

                return resultado;
            }
            


            return null;

        }



        //Método para eliminar desde el front
        public async Task<bool> Eliminar(Guid id)
        {
            bool respuesta = false;


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);



            var response = await cliente.DeleteAsync($"api/Tipo_Ticket/Elimina/(\"{id}\")");


            Console.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<ApplicationResponse<Tipo_TicketDTOUpdate>> Actualizar(Tipo_TicketDTOUpdate tipo)
        {
            bool respuesta = false;


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(tipo));


            var response = await cliente.PutAsync("api/Tipo_Ticket/Editar/"+tipo.Id, content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                Console.WriteLine(JsonConvert.SerializeObject(json_respuesta));
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<Tipo_TicketDTOUpdate>>(json_respuesta);

                return resultado;
            }



            return null;
        }
    }

}
