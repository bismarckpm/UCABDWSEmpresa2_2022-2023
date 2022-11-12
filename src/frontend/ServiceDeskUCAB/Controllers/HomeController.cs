using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ViewModel;
using ServiceDeskUCAB.Servicios;
using System.Diagnostics;
using System.Dynamic;

namespace ServiceDeskUCAB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;



        public HomeController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }


        public async Task<IActionResult> VistaTipoTicket()
        {
            TipoNuevoViewModel tipoNuevoViewModel = new TipoNuevoViewModel();

            tipoNuevoViewModel.ListaTipo = await _servicioApi.Lista();
            tipoNuevoViewModel.tipo = new();
            tipoNuevoViewModel.tipoCargoNuevo = new();


            return View(tipoNuevoViewModel);
        }



        [HttpGet]
        public async Task<IActionResult> EliminarTipoTicket(int idProducto)
        {

            var respuesta = await _servicioApi.Eliminar(idProducto);

            if (respuesta)
                return RedirectToAction("VistaTipoTicket");
            else
                return NoContent();
        }

        public async Task<IActionResult> Index()
        {
   
            return View();
        }
    }
}