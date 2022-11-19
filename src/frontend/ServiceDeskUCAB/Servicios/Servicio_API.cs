using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServicesDeskUCAB.Models.TipoTicketModels;
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
        public async Task<bool> Guardar(Tipo_TicketDTOCreate tipo)
        {
            bool respuesta = false;


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(tipo), Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(tipo));
            

            var response = await cliente.PostAsync("api/Tipo_Ticket/Guardar/", content);


         

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
                Console.WriteLine(respuesta);

            }

            return respuesta;
            Console.WriteLine(respuesta);

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


    }

}
