
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using ServiceDeskUCAB.Models.Modelos_de_Usuario;

namespace ServiceDeskUCAB.Servicios
{
    public class ServicioUsuario_API : IServicioUsuario_API
    {
        private static string _baseUrl;
        private JObject _json_respuesta;
        public ServicioUsuario_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<JObject> Eliminar(Guid id)
        {
            HttpClient usuario = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await usuario.DeleteAsync($"api/Usuario/EliminarUsuario/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        public async Task<JObject> Guardar(UsuariosRol usuarios)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string json = await Task.Run(() => JsonConvert.SerializeObject(usuarios));
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(usuarios));

            try
            {
                var response = await cliente.PostAsync("api/Usuario/CrearCliente", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        public async Task<JObject> GuardarEmpleado(UsuariosRol usuarios)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string json = await Task.Run(() => JsonConvert.SerializeObject(usuarios));
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(usuarios));

            try
            {
                var response = await cliente.PostAsync("api/Usuario/CrearEmpleado", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        public async Task<JObject> GuardarAdminstrador(UsuariosRol usuarios)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string json = await Task.Run(() => JsonConvert.SerializeObject(usuarios));
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine(JsonConvert.SerializeObject(usuarios));

            try
            {
                var response = await cliente.PostAsync("api/Usuario/CrearAdministrador", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        public async Task<Roles> ObtenerRoles(Guid id)
        {
            Roles roles = new();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseUser = await cliente.GetAsync($"api/AsignacionRol/AsignacionRol/{id}");

                if (responseUser.IsSuccessStatusCode)
                {
                    var respuestaUser = await responseUser.Content.ReadAsStringAsync();
                    JObject json_respuestaUser = JObject.Parse(respuestaUser);

                    string stringDataRespuestaUser = json_respuestaUser["data"].ToString();
                    Console.WriteLine(stringDataRespuestaUser);
                    var resultadoUser = JsonConvert.DeserializeObject<Roles>(stringDataRespuestaUser);
                    roles = resultadoUser;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return roles;
        }

        public async Task<List<UsuariosRol>> Lista()
        {
            List<UsuariosRol> listaUsuarios = new();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var response = await cliente.GetAsync("api/Usuario");

                if (response.IsSuccessStatusCode)
                {
                    var respuesta = await response.Content.ReadAsStringAsync();
                    JObject json_respuesta = JObject.Parse(respuesta);

                    //Obtengo la data del json respuesta
                    string stringDataRespuesta = json_respuesta["data"].ToString();
                    var resultado = JsonConvert.DeserializeObject<List<UsuariosRol>>(stringDataRespuesta);

                    //var resultado = JsonConvert.DeserializeObject<List<PlantillaNotificacion>>(json_respuesta);
                    listaUsuarios = resultado;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return listaUsuarios;
        }

        public async Task<UsuariosRol> MostrarInfoUsuario(Guid id)
        {
            UsuariosRol usuario = new UsuariosRol();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseUser = await cliente.GetAsync($"api/Usuario/Consulta/Usuario/{id}");

                if (responseUser.IsSuccessStatusCode)
                {
                    var respuestaUser = await responseUser.Content.ReadAsStringAsync();
                    JObject json_respuestaUser = JObject.Parse(respuestaUser);

                    string stringDataRespuestaDept = json_respuestaUser["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<UsuariosRol>(stringDataRespuestaDept);
                    usuario = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return usuario;
        }

        public async Task<JObject> EditarUsuario(UpdateUser user)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("api/Usuario/ActualizarUsuario", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }

        public async Task<JObject> EliminarRol(RolUser user)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.DeleteAsync($"api/AsignacionRol/EliminarRol/{user.idusuario}");
                var respuesta = await response.Content.ReadAsStringAsync();


                var responseAgregate = await cliente.PostAsync("api/AsignacionRol/AsignarRol", content);
                var respuestaAgregate = await response.Content.ReadAsStringAsync();

                JObject _json_respuesta = JObject.Parse(respuesta);
                JObject _json_respuestaAgregate = JObject.Parse(respuestaAgregate);

                return _json_respuestaAgregate;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }



        public async Task<JObject> ValidarLogin(Credenciales_Login user)
        {

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("api/Usuario/login", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;
        }


        public async Task<JObject> RecuperarContraseña(RecuperarPasswordModel email)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            try
            {
                var response = await cliente.PostAsync("api/Usuario/RecuperarClave", content);
                var respuesta = await response.Content.ReadAsStringAsync();
                JObject _json_respuesta = JObject.Parse(respuesta);
                return _json_respuesta;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ERROR de conexión con la API: '{ex.Message}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return _json_respuesta;

        }

    }
}
