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
            var idUsuario = //"E7AFDCF7-11DA-49FD-8503-C630D524DD55"; //Claim de Id usuario
                            "4913F598-71FD-4E55-B38A-F5D471F18296";
            List<Votos_Ticket> lista = await _servicioApi.ObtenerVotos(idUsuario);

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
                return RedirectToAction("VistaTicket", new { message = "Voto registrado exitosamente"});
            else
                return RedirectToAction("VistaVotarTicket", new { message = "Error ingresando voto" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
