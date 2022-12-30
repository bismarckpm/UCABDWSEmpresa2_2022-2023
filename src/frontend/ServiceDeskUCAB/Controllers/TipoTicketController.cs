using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.Response;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using ServiceDeskUCAB.Models.ViewModel;
using ServiceDeskUCAB.Servicios;
using System.Drawing;

namespace ServiceDeskUCAB.Controllers
{

    [Authorize(Policy = "AdminAccess")]
    public class TipoTicketController : Controller
    {
       
       

        private readonly IServicio_API _servicioApi;
        private readonly IServicioTicketAPI _servicioTicketAPI;

        public TipoTicketController(IServicio_API servicioApi, IServicioTicketAPI servicioTicketAPI)
        {
            _servicioApi = servicioApi;
            _servicioTicketAPI = servicioTicketAPI;
        }


        public async Task<IActionResult> VistaTipo(string idDepartamento)
        {
            TipoNuevoViewModel tipoNuevoViewModel = new TipoNuevoViewModel();
            tipoNuevoViewModel.idDepartamento = idDepartamento;
            tipoNuevoViewModel.ListaTipo = await _servicioApi.Lista();
            tipoNuevoViewModel.tipo = new Tipo();
            tipoNuevoViewModel.tipoActualizar = new Tipo();
            tipoNuevoViewModel.tipoCargoNuevo = new();
            tipoNuevoViewModel.ListaDepartamento = await _servicioApi.ListaDepa();
            tipoNuevoViewModel.ListaCargos = await _servicioApi.ListaCargos(Guid.Parse(idDepartamento));
            tipoNuevoViewModel.listaModelos = await _servicioApi.ObtenerListaModelosAprobacion();

            int i = 0;
            foreach (var r in tipoNuevoViewModel.ListaCargos)
            {
                
                r.posicion = i;
                i++;
            }

            ViewBag.Error = "Mensaje de Error no personalizado";
            
            return View(tipoNuevoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCambios (Tipo tipo,string tipot, List<string> departamentos, List<string> cargos2, List<int> ordenaprobacion, List<int> minimo_aprobado_nivel, List<int> maximo_rechazado_nivel, string idDepartOrigen)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            var departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);

            ApplicationResponse<Tipo_TicketDTOUpdate> respuesta;

            var TipoTicketDTO = new Tipo_TicketDTOUpdate();
            TipoTicketDTO.Id = tipo.Id;
            TipoTicketDTO.Departamento = departamentos;
            TipoTicketDTO.nombre = tipo.nombre;
            TipoTicketDTO.tipo = tipot;
            TipoTicketDTO.Minimo_Aprobado = tipo.Minimo_Aprobado;
            TipoTicketDTO.Maximo_Rechazado = tipo.Maximo_Rechazado;
            TipoTicketDTO.descripcion = tipo.descripcion;
            TipoTicketDTO.Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate>();
            var ListaCargos = await _servicioApi.ListaCargos(Guid.Parse(idDepartOrigen));

            var ListanuevoCargo = ListaCargos.Where(x => cargos2.Contains(x.Id.ToString())).ToList();

            int i = 0;
            if (TipoTicketDTO.tipo == "Modelo_Jerarquico")
            {
                foreach (var cargo in ListanuevoCargo)
                {
                    TipoTicketDTO.Flujo_Aprobacion.Add(new FlujoAprobacionDTOCreate()
                    {
                        IdCargo = cargo.Id.ToString(),
                        OrdenAprobacion = ordenaprobacion[i],
                        Minimo_aprobado_nivel = minimo_aprobado_nivel[i],
                        Maximo_Rechazado_nivel = maximo_rechazado_nivel[i]
                    });
                    i++;
                }
            }
            if (TipoTicketDTO.tipo == "Modelo_Paralelo")
            {
                foreach (var cargo in ListanuevoCargo)
                {
                    TipoTicketDTO.Flujo_Aprobacion.Add(new FlujoAprobacionDTOCreate()
                    {
                        IdCargo = cargo.Id.ToString()
                    });
                    i++;
                }
            }

            /*if (TipoTicketDTO.tipo == "Modelo_No_Aprobacion")
            {
                TipoTicketDTO.Flujo_Aprobacion = null;
            }*/
            respuesta = await _servicioApi.Actualizar(TipoTicketDTO);

            if(respuesta != null)
            {
                if (respuesta.Success)
                {
                    return RedirectToAction("VistaTipo", new { idDepartamento= idDepartOrigen, message2 = "El tipo Ticket fue modificado satisfactoriamente" });
                }
                else
                {
                    return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message = respuesta.Message });
                }
            }


            else
                return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message = "Fallo la creacion del tipo ticket por error en la comunicacion con el servidor" });
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Tipo tipoTicket, List<string> departamentos,List<string> cargos2, List<int> ordenaprobacion, List<int> minimo_aprobado_nivel, List<int> maximo_rechazado_nivel, string idDepartOrigen)
        {
            ApplicationResponse<Tipo_TicketDTOCreate> respuesta;

            var TipoTicketDTO = new Tipo_TicketDTOCreate();
            TipoTicketDTO.Departamento = departamentos;
            TipoTicketDTO.nombre = tipoTicket.nombre;
            TipoTicketDTO.Minimo_Aprobado = tipoTicket.Minimo_Aprobado;
            TipoTicketDTO.Maximo_Rechazado = tipoTicket.Maximo_Rechazado;
            TipoTicketDTO.descripcion = tipoTicket.descripcion;
            TipoTicketDTO.tipo = tipoTicket.tipo;
            TipoTicketDTO.Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate>();
            var ListaCargos=await _servicioApi.ListaCargos(Guid.Parse(idDepartOrigen));

            var ListanuevoCargo = ListaCargos.Where(x=>cargos2.Contains(x.Id.ToString())).ToList();
            
            int i = 0;
            if (TipoTicketDTO.tipo == "Modelo_Jerarquico")
            {
                foreach (var cargo in ListanuevoCargo)
                {
                    TipoTicketDTO.Flujo_Aprobacion.Add(new FlujoAprobacionDTOCreate()
                    {
                        IdCargo = cargo.Id.ToString(),
                        OrdenAprobacion = ordenaprobacion[i],
                        Minimo_aprobado_nivel = minimo_aprobado_nivel[i],
                        Maximo_Rechazado_nivel = maximo_rechazado_nivel[i]
                    });
                    i++;
                }
            }
            if (TipoTicketDTO.tipo == "Modelo_Paralelo")
            {
                foreach (var cargo in ListanuevoCargo)
                {
                    TipoTicketDTO.Flujo_Aprobacion.Add(new FlujoAprobacionDTOCreate()
                    {
                        IdCargo = cargo.Id.ToString()
                    });
                    i++;
                }
            }

            /*if (TipoTicketDTO.tipo == "Modelo_No_Aprobacion")
            {
                TipoTicketDTO.Flujo_Aprobacion = null;
            }*/
            respuesta = await _servicioApi.Guardar(TipoTicketDTO);

            if (respuesta != null)
            {
                if(respuesta.Success)
                {
                   return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message2 = "El tipo Ticket fue agregado satisfactoriamente" });
                }
                else
                 {
                   return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message = respuesta.Exception });
                 }
            }

            else
            {
                return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message = "Fallo la creacion del tipo ticket por error en la comunicacion con el servidor" });
            }
                

        }
        public async Task<IActionResult> Eliminar(Guid id, string idDepartOrigen)
        {
            Console.WriteLine(id);

            var respuesta = await _servicioApi.Eliminar(id);

            if (respuesta)
                return RedirectToAction("VistaTipo",new { idDepartamento = idDepartOrigen, message2 ="Tipo Ticket eliminado exitosamente"});
            else
                return RedirectToAction("VistaTipo", new { idDepartamento = idDepartOrigen, message = "Error al eliminar el tipo ticket" });
        }



    }
}
