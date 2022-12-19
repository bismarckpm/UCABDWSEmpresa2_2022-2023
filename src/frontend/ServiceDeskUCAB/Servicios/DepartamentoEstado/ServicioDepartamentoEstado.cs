using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Servicios.DepartamentoEstado
{
    public class ServicioDepartamentoEstado : IServicioDepartamentoEstado
    {

        public static string _baseUrl;


        public ServicioDepartamentoEstado()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;


        }

        

        public async Task<ApplicationResponse<EstadoDTOUpdate>> EditarEstado(EstadoDTOUpdate estadoDTO)
        {
            var estado = new ApplicationResponse<EstadoDTOUpdate> ();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(estadoDTO), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Estado/Editar",content);  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<EstadoDTOUpdate>>(json_respuesta);


                estado = resultado;
            }


            return estado;
        }

        public async  Task<List<EstadoDTOUpdate>> ListaEstado(Guid Id)
        {
            var lista = new List<EstadoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("api/Estado/Consulta/"+Id);  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                /*JObject dataRespuesta = JObject.Parse(json_respuesta);

                string stringDataRespuesta = dataRespuesta["data"].ToString();
                Console.WriteLine(stringDataRespuesta);*/

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<List<EstadoDTOUpdate>>> (json_respuesta);


                lista = resultado.Data;
            }


            return lista;
        }

        public async Task<ApplicationResponse<EstadoDTOUpdate>> DeshabilitarEstado(Guid Id)
        {
            var lista = new ApplicationResponse<EstadoDTOUpdate>() ;


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.PutAsync("api/Estado/DeshabilitarEstado/" + Id, null); 

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<EstadoDTOUpdate>>(json_respuesta);


                lista = resultado;

            }
            return lista;
        }

        public async Task<ApplicationResponse<EstadoDTOUpdate>> HabilitarEstado(Guid Id)
        {
            var lista = new ApplicationResponse<EstadoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.PutAsync("api/Estado/HabilitarEstado/" + Id, null);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<EstadoDTOUpdate>>(json_respuesta);


                lista = resultado;

            }
            return lista;
        }

    }



}
