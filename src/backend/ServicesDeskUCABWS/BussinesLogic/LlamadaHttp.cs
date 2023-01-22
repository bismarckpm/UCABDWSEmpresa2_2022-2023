using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace ServicesDeskUCABWS.BussinesLogic
{
    public class LlamadaHttp
    {
        string _baseUrl= "https://localhost:44392/";
        public async Task<T> GetAsyncFromServer<T>(string Url)
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
        }

        public async Task<T> PutAsyncFromServer<T>(string Url, StringContent content)
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

        public async Task<T> PostAsyncFromServer<T>(string Url, StringContent content)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = cliente.PostAsync(Url, content);
            if (response.Result.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Result.Content.ReadAsStringAsync();
                JObject dataRespuesta = JObject.Parse(json_respuesta);
                string stringDataRespuesta = dataRespuesta.ToString();
                return JsonConvert.DeserializeObject<T>(stringDataRespuesta);
            }
            throw new Exception("Error de conexion con el servidor");
        }

        public async Task<bool> DeleteAsyncFromServer(string Url)
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

       
    }
}
