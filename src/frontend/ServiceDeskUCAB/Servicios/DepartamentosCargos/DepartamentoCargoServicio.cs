using Newtonsoft.Json;
using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Models.Response;
using ServicesDeskUCAB.Models.DTO.CargoDTO;
using System.Text;

namespace ServiceDeskUCAB.Servicios.DepartamentosCargos
{
    public class DepartamentoCargoServicio : IDepartamentoCargoServicio
    {
        public static string _baseUrl;


        public DepartamentoCargoServicio()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;


        }

        public async Task<ApplicationResponse<CargoDTOCreate>> RegistrarCargo(CargoDTOCreate cargoDTOCreate)
        {
            var cargo = new ApplicationResponse<CargoDTOCreate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(cargoDTOCreate), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Cargo/CrearCargo", content);  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<CargoDTOCreate>>(json_respuesta);


                cargo = resultado;
            }


            return cargo;
        }

        public async Task<ApplicationResponse<CargoDTOUpdate>> EditarCargo(CargoDTOUpdate estadoDTO)
        {
            var estado = new ApplicationResponse<CargoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(estadoDTO), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("Cargo/Editar", content);  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<CargoDTOUpdate>>(json_respuesta);


                estado = resultado;
            }


            return estado;
        }

        public async Task<List<CargoDTOUpdate>> ListaCargo(Guid Id)
        {
            var lista = new List<CargoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("Cargo/ConsultarCargoPorDepartamento/" + Id);  //URL de Lista en el swagger

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                /*JObject dataRespuesta = JObject.Parse(json_respuesta);

                string stringDataRespuesta = dataRespuesta["data"].ToString();
                Console.WriteLine(stringDataRespuesta);*/

                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<List<CargoDTOUpdate>>>(json_respuesta);


                lista = resultado.Data;
            }


            return lista;
        }

        public async Task<ApplicationResponse<CargoDTOUpdate>> DeshabilitarCargo(Guid Id)
        {
            var lista = new ApplicationResponse<CargoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.PutAsync("Cargo/DeshabilitarCargo/" + Id, null);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<CargoDTOUpdate>>(json_respuesta);


                lista = resultado;

            }
            return lista;
        }

        public async Task<ApplicationResponse<CargoDTOUpdate>> HabilitarCargo(Guid Id)
        {
            var lista = new ApplicationResponse<CargoDTOUpdate>();


            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.PutAsync("Cargo/HabilitarCargo/" + Id, null);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ApplicationResponse<CargoDTOUpdate>>(json_respuesta);


                lista = resultado;

            }
            return lista;
        }

        
    }
}
