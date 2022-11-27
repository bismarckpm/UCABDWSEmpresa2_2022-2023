using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ServiceDeskUCAB.Models;
using System.Text;


namespace ServiceDeskUCAB.Servicios.ModuloCargo
{
    public class ServicioCargo_API : IServicioCargo_API
    {
        //Declaracion de variables
        private static string _baseUrl;
        private JObject _json_respuesta;

        //Constructor
        public ServicioCargo_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        //Eliminar un cargo seleccionado
        public async Task<JObject> EliminarCargo(Guid id)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            var response = await cliente.DeleteAsync($"Cargo/eliminarcargo/{id}");

            var respuesta = await response.Content.ReadAsStringAsync();
            JObject json_respuesta = JObject.Parse(respuesta);

            return json_respuesta;
        }

        //Carga la lista de departamentos y grupos
        public async Task<Tuple<List<CargoModel>, List<Tipo_CargoModel>>> ListaCargoTipoCargo()
        {
            List<CargoModel> listaCargo = new List<CargoModel>();
            List<Tipo_CargoModel> listaTipo = new List<Tipo_CargoModel>();

            var cliente = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync("Cargo/ConsultarCargoNoEliminado");
                var responseTipo = await cliente.GetAsync("Tipo_Cargo/ConsultarTipoCargoNoEliminado");

                if (responseCargo.IsSuccessStatusCode && responseTipo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    var respuestaTipo = await responseTipo.Content.ReadAsStringAsync();
                    JObject json_respuestaTipo = JObject.Parse(respuestaTipo);


                    //Obtengo la data del json respuesta Departamento
                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<List<CargoModel>>(stringDataRespuestaCargo);

                    //Obtengo la data del json respuesta Grupo
                    string stringDataRespuestaTipo = json_respuestaTipo["data"].ToString();
                    var resultadoTipo = JsonConvert.DeserializeObject<List<Tipo_CargoModel>>(stringDataRespuestaTipo);


                    listaCargo = resultadoCargo;
                    listaTipo = resultadoTipo;
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

            var tupla = new Tuple<List<CargoModel>, List<Tipo_CargoModel>>(listaCargo, listaTipo);

            return tupla;
        }



        //Almacenar la información de un nuevo cargo
        public async Task<JObject> RegistarCargo(CargoModel cargo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(cargo), Encoding.UTF8, "application/json");
            Console.WriteLine(JsonConvert.SerializeObject(cargo));

            try
            {
                var response = await cliente.PostAsync("Cargo/CrearCargo/", content);
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

        //Modificar los campos de un departamento
        public async Task<CargoModel> MostrarInfoCargo(Guid id)
        {
            CargoModel cargo = new CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseDept = await cliente.GetAsync($"Cargo/ConsultarPorID/{id}");

                if (responseDept.IsSuccessStatusCode)
                {
                    var respuestaDept = await responseDept.Content.ReadAsStringAsync();
                    JObject json_respuestaDept = JObject.Parse(respuestaDept);

                    string stringDataRespuestaDept = json_respuestaDept["data"].ToString();
                    var resultadoDept = JsonConvert.DeserializeObject<CargoModel>(stringDataRespuestaDept);
                    cargo = resultadoDept;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return cargo;
        }

        public async Task<JObject> EditarCargo(CargoModel cargo)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var content = new StringContent(JsonConvert.SerializeObject(cargo), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync("Cargo/ActualizarCargo/", content);
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

        public async Task<List<CargoModel>> CargoAsociadoTipoCargo(Guid id)
        {
            CargoModel cargo = new CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync($"Cargo/ConsultarCargoPorIdTipoCargo/{id}");

                if (responseCargo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<List<CargoModel>>(stringDataRespuestaCargo);
                    cargo.cargos = resultadoCargo;
                }


            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return cargo.cargos;
        }

        //Asociar un departamento seleccionado
        public async Task<JObject> AsociarCargo(Guid id, List<string> idCargos)
        {
            CargoModel model = new CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string combinedString = string.Join(",", idCargos);
            var contentCargo = new StringContent(JsonConvert.SerializeObject(combinedString), Encoding.UTF8, "application/json");

            try
            {
                var responseCargo = await cliente.PutAsync($"Cargo/AsignarTipoCargotoCargo/{id}", contentCargo);
                var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                JObject json_respuesta = JObject.Parse(respuestaCargo);
                return json_respuesta;

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
        public async Task<List<CargoModel>> ListaCargo()
        {
            CargoModel cargo = new CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync("Cargo/ConsultarCargoNoEliminado/");

                if (responseCargo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<List<CargoModel>>(stringDataRespuestaCargo);
                    cargo.cargos = resultadoCargo;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return cargo.cargos;
        }

        public async Task<List<CargoModel>> ListaCargoNoAsociado()
        {
            CargoModel cargo = new CargoModel();

            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            try
            {
                var responseCargo = await cliente.GetAsync("Cargo/ConsultarCargoNoAsociado/");

                if (responseCargo.IsSuccessStatusCode)
                {
                    var respuestaCargo = await responseCargo.Content.ReadAsStringAsync();
                    JObject json_respuestaCargo = JObject.Parse(respuestaCargo);

                    string stringDataRespuestaCargo = json_respuestaCargo["data"].ToString();
                    var resultadoCargo = JsonConvert.DeserializeObject<List<CargoModel>>(stringDataRespuestaCargo);
                    cargo.cargos = resultadoCargo;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return cargo.cargos;
        }


        public async Task<JObject> EditarRelacion(Guid id, List<string> idCargos)
        {
            HttpClient cliente = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };

            string combinedString = string.Join(",", idCargos);
            var content = new StringContent(JsonConvert.SerializeObject(combinedString), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PutAsync($"Cargo/EditarRelacion/{id}", content);
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
