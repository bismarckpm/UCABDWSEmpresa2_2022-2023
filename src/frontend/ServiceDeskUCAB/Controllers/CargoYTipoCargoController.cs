using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
//using ServicesDeskUCAB.Servicios.ModuloTipoCargo;
//using ServicesDeskUCAB.Servicios.ModuloCargo;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
//using ServicesDeskUCAB.Models;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServiceDeskUCAB.Servicios.ModuloCargo;
using ServiceDeskUCAB.Servicios.ModuloTipoCargo;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCAB.Controllers
{
    public class CargoYTipoCargoController : Controller
    {

        //Declaración de variables
        private readonly ILogger<CargoYTipoCargoController> _logger;
        private readonly IServicioCargo_API _servicioApiCargo;
        private readonly IServicioTipo_Cargo_API _servicioApiTipoCargo;

        //Constructor
        public CargoYTipoCargoController(ILogger<CargoYTipoCargoController> logger, IServicioCargo_API servicioApiCargo, IServicioTipo_Cargo_API servicioApiTipoCargo)
        {
            _logger = logger;
            _servicioApiCargo = servicioApiCargo;
            _servicioApiTipoCargo = servicioApiTipoCargo;
        }

        //Inicia la petición HTTP a la API para Obtener todas los departamentos a traves del servicio ServicioDepartamento_API
        public async Task<IActionResult> CargoTipoCargo()
        {
            var tupla = new Tuple<List<CargoDto>, List<Tipo_CargoDto>>(null, null);
            tupla = await _servicioApiCargo.ListaCargoTipoCargo();
            return View(tupla);
        }

        //Retorna el modal para registrar un cargo nuevo
        public IActionResult AgregarCargo()
        {
            try
            {
                return PartialView();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Almacena la información referente a un nuevo cargo
        [HttpPost]
        public async Task<IActionResult> RegistarCargo(CargoDto cargo)
        {

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiCargo.RegistarCargo(cargo);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("CargoTipoCargo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        //Retorna el modal para eliminar un cargo
        public IActionResult VentanaEliminarCargo(Guid id)
        {
            try
            {
                return PartialView(id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Elimina a un cargo que ha sido seleccionado previamente
        [HttpGet]
        public async Task<IActionResult> EliminarCargo(Guid id)
        {
            JObject respuesta;
            respuesta = await _servicioApiCargo.EliminarCargo(id);
            if ((bool)respuesta["success"])
                return RedirectToAction("CargoTipoCargo", new { message = "Se ha eliminado correctamente" });
            else
                return NoContent();
        }

        public async Task<IActionResult> VentanaEditarCargo(Guid id)
        {
            try
            {
                CargoModel cargo = new CargoModel();
                cargo = await _servicioApiCargo.MostrarInfoCargo(id);
                return PartialView(cargo);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        public async Task<IActionResult> ModificarCargo(CargoDto_Update cargo)
        {
            try
            {
                JObject respuesta;
                respuesta = await _servicioApiCargo.EditarCargo(cargo);
                if ((bool)respuesta["success"])
                    return RedirectToAction("CargoTipoCargo", new { message = "Se ha modificado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        /////////////
        ///Operaciones de grupo
        ////////////

        //Retorna el modal con los departamentos que estan asociados a un grupo

        //public async Task<IActionResult> AsociarTipoCargo(Tipo_CargoModel tipo, List<string> idCargos)
        //{
        //    JObject respuesta;

        //    try
        //    {

        //        respuesta = await _servicioApiCargo.AsociarCargo(tipo.id, idCargos);
        //        if ((bool)respuesta["success"])
        //            return RedirectToAction("CargoTipoCargo", new { message = "Se ha asociado correctamente" });
        //        else
        //            return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException!;
        //    }
        //}

        public async Task<IActionResult> VentanaVisualizarCargo(Guid id)
        {
            List<CargoModel> cargo = new List<CargoModel>();
            Tipo_CargoModel model = new Tipo_CargoModel();

            try
            {
                model = await _servicioApiTipoCargo.BuscarTipoCargo(id);
                ViewData["nombre"] = model.nombre;
                cargo = await _servicioApiCargo.CargoAsociadoTipoCargo(id);
                return PartialView(cargo);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }
        //Retorna el modal de confirmación para eliminar un grupo
        public IActionResult VentanaEliminarTipoCargo(Guid id)
        {
            try
            {
                return PartialView(id);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Elimina a un cargo que ha sido seleccionado previamente
        [HttpGet]
        public async Task<IActionResult> EliminarTipo_Cargo(Guid id)
        {
            JObject respuesta;
            respuesta = await _servicioApiTipoCargo.EliminarTipo_Cargo(id);
            if ((bool)respuesta["success"])
                return RedirectToAction("CargoTipoCargo", new { message = "Se ha eliminado correctamente" });
            else
                return NoContent();
        }



        public IActionResult AgregarTipoCargo()
        {
            Tipo_CargoModel tipo = new Tipo_CargoModel();

            try
            {
                return PartialView(tipo);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
            return NoContent();
        }

        //Retorna el modal para registrar un grupo nuevo
        //Almacena la información referente a un nuevo cargo
        [HttpPost]
        public async Task<IActionResult> GuardarTipoCargo(Tipo_CargoModel tipo)
        {
            JObject respuestaTipo;

            try
            {
                respuestaTipo = await _servicioApiTipoCargo.RegistarTipo_Cargo(tipo);
                return RedirectToAction("CargoTipoCargo");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();

        }





    }

    //



}
