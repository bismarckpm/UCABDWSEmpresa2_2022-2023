using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Servicios;

namespace ServiceDeskUCAB.Controllers
{
    public class VotosController : Controller
    {
        private readonly IServicio_API _servicioApi;
        public VotosController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> VistaTicket()
        {
            List<Votos_Ticket> lista = await _servicioApi.ObtenerVotos();

            return View(lista);
        }



        [HttpGet]
        public async Task<IActionResult> AgregarTicket()
        {

            var ticket = new NuevoTicket();

            var departamentos = await _servicioApi.ListaDepa();
            var prioridades = await _servicioApi.ObtenerPrioridades();
            var tipos = await _servicioApi.Lista();

            ViewData["Departamentos"] = departamentos;
            ViewData["Prioridades"] = prioridades;
            ViewData["Tipos"] = tipos;

            return View(ticket);
        }


        [HttpPost]
        public async Task<IActionResult> GuardarTicket(NuevoTicket ticket, string Emisor)
        {
            ticket.emisor = Emisor;
            var respuesta = await _servicioApi.AgregarTicket(ticket);

            if (respuesta)
                return RedirectToAction("VistaTicket");
            else
                return NoContent();
        }

        // controladores para votar ticket, Get de vista y Post de Guardar

        [HttpGet]
        public async Task<IActionResult> VistaVotarTicket(Ticket ticket, string idUsuario, string idTicket, string voto, string comentario)
        {
            var newVoto = new VotarTicket() { IdTicket = idTicket, IdUsuario = idUsuario, comentario = comentario, voto = voto };
            var res = await _servicioApi.ObtenerTicket(idTicket);

            ViewData["Ticket"] = res;
            return View(newVoto);
        }


        [HttpPost]
        public async Task<IActionResult> VotarTicket(VotarTicket voto_ticket)
        {

            var respuesta = await _servicioApi.VotarTicket(voto_ticket);

            if (respuesta.Success)
                return RedirectToAction("VistaTicket");
            else
                return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
