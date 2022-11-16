using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ViewModel;
using ServiceDeskUCAB.Servicios;

namespace ServiceDeskUCAB.Controllers
{
    public class TipoTicketController : Controller
    {
       
       

        private readonly IServicio_API _servicioApi;



        public TipoTicketController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }


        public async Task<IActionResult> VistaTipo()
        {

            TipoNuevoViewModel tipoNuevoViewModel = new TipoNuevoViewModel();

            tipoNuevoViewModel.ListaTipo = await _servicioApi.Lista();
            tipoNuevoViewModel.tipo = new();
            tipoNuevoViewModel.tipoCargoNuevo = new();
            tipoNuevoViewModel.ListaDepartamento = await _servicioApi.ListaDepa();
            tipoNuevoViewModel.ListaCargos = await _servicioApi.ListaCargos();


            return View(tipoNuevoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(TipoNuevo ob_producto, List<string> departamentos, TipoCargoNuevo flujoAprobacion)
        {
            bool respuesta;

            ob_producto.departamento = departamentos;
            ob_producto.flujo_Aprobacion = new();
            ob_producto.flujo_Aprobacion.Add(flujoAprobacion);


            //if (ob_producto.Id == Guid.Empty)
            //{
            respuesta = await _servicioApi.Guardar(ob_producto);
            //}
            //else
            //{
            //    respuesta = await _servicioApi.Editar(ob_producto);
            //}


            if (respuesta)
                return RedirectToAction("VistaTipo");
            else
                return NoContent();

        }
        public async Task<IActionResult> Eliminar(Guid id)
        {
            Console.WriteLine(id);

            var respuesta = await _servicioApi.Eliminar(id);

            if (respuesta)
                return RedirectToAction("VistaTipo");
            else
                return NoContent();
        }



    }
}
