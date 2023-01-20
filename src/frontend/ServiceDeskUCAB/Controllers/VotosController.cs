using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Servicios;

namespace ServiceDeskUCAB.Controllers
{
    [Authorize(Policy = "EmpleadoAccess")]
    public class VotosController : Controller
    {
        private readonly IServicio_API _servicioApi;
        public VotosController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> VistaTicket()
        {
            try
            {
                var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
                List<Votos_Ticket> lista = await _servicioApi.ObtenerVotos(idUsuario);

                return View(lista);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }

        // controladores para votar ticket, Get de vista y Post de Guardar
        [HttpGet]
        public async Task<IActionResult> VistaVotarTicket(Ticket ticket, string idUsuario, string idTicket, string voto, string comentario)
        {
            try
            {
                var newVoto = new VotarTicket() { IdTicket = idTicket, IdUsuario = idUsuario, comentario = comentario, voto = voto };
                var res = await _servicioApi.ObtenerTicket(idTicket);
                if (res.Success == false)
                {
                    return RedirectToAction("VistaTicket", new { message = res.Message });
                }
                ViewData["Ticket"] = res.Data;
                return View(newVoto);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> VotarTicket(VotarTicket voto_ticket)
        {
            try
            {
                var respuesta = await _servicioApi.VotarTicket(voto_ticket);

                if (respuesta.Success)
                    return RedirectToAction("VistaTicket", new { message2 = "Voto registrado exitosamente" });
                else
                    return RedirectToAction("VistaTicket", new { message = "Error ingresando voto: "+ respuesta.Message });
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarVoto(Ticket ticket, string idUsuario, string idTicket, string voto, string comentario)
        {
            try
            {
                var voto_ticket = new VotarTicket() { IdTicket = idTicket, IdUsuario = idUsuario, comentario = comentario, voto = voto };
                var res = await _servicioApi.ObtenerTicket(idTicket);
                if (res.Success == false)
                {
                    return RedirectToAction("VistaTicket", new { message = res.Message });
                }
                ViewData["Ticket"] = res.Data;
                return View(voto_ticket);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }

        public async Task<IActionResult> VistaTicketNoPendiente()
        {
            try
            {
                var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
                List<Votos_Ticket> listaNP = await _servicioApi.ObtenerVotosNoPendientes(idUsuario);

                return View(listaNP);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message });
            }
        }
    }
}
