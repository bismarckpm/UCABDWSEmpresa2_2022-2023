using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Controllers.Tipo_TicketCtr
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_TicketController : Controller
    {
        private readonly DataContext _context;
        private readonly ITipo_TicketDAO _ticketDAO;
        private readonly IMapper _mapper;

        public Tipo_TicketController(ITipo_TicketDAO ticketDAO, DataContext context, IMapper mapper)
        {
            _context = context;
            _ticketDAO = ticketDAO;
            _mapper = mapper;

        }


        //GET: Controlador para consultar la tipo ticket 
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<IEnumerable<Tipo_TicketDTOSearch>> ConsultarTipoTicketCtrl()
        {
            var response = new ApplicationResponse<IEnumerable<Tipo_TicketDTOSearch>>();

            try
            {
                response.Data = _ticketDAO.ConsultarTipoTicket();
            }

            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        // PUT: api/Tipo_Ticket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ApplicationResponse<Tipo_TicketDTOUpdate> EditarTipo_Ticket(Tipo_TicketDTOUpdate tipo_Ticket)
        {
            var response = _ticketDAO.ActualizarTipo_Ticket(tipo_Ticket);
            return response;
        }

        // POST: api/Tipo_Ticket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ApplicationResponse<Tipo_Ticket> PostTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTO)
        {
            var response = _ticketDAO.RegistroTipo_Ticket(tipo_TicketDTO);
            return response;
        }
        //GET: Controlador para consultar tipo ticket por un id
        [HttpGet]
        [Route("Consulta/(\"{id}\")")]
        public async Task<ActionResult<ApplicationResponse<Tipo_TicketDTOSearch>>> GetByGuidCtrl(Guid id)

        {
            var response = new ApplicationResponse<Tipo_TicketDTOSearch>();
            try
            {
                response.Data = await _ticketDAO.ConsultarTipoTicketGUID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        //GET: Controlador para consultar una tipo de ticket por un nombre específico
        [HttpGet]
        [Route("Consulta/{nombre}")]
        public async Task<ApplicationResponse<Tipo_TicketDTOSearch>> GetBynombreCtrl(string nombre)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOSearch>();
            try
            {
                response.Data = await _ticketDAO.ConsultarTipoTicketNomb(nombre);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //DELETE: Controlador para eliminar tipo ticket
        [HttpDelete]
        [Route("Elimina/(\"{id}\")")]
        public async Task<ApplicationResponse<String>> EliminarTipoTicketCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();

            try
            {

                var result = _ticketDAO.EliminarTipoTicket(id);
                response.Data = result.ToString();
            }

            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;


        }

        // DELETE: api/Tipo_Ticket/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_Ticket(Guid id)
        {
            var tipo_Ticket = await _context.Tipos_Tickets.FindAsync(id);
            if (tipo_Ticket == null)
            {
                return NotFound();
            }

            _context.Tipos_Tickets.Remove(tipo_Ticket);
            await _context.SaveChangesAsync();

        // POST: Tipo_Ticket/Delete/Controlador
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tipos_Tickets == null)
            {
                return Problem("Entity set 'DataContext.Tipos_Tickets'  is null.");
            }
            await tipo_TicketDAO.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_TicketExists(Guid id)
        {
            return _context.Tipos_Tickets.Any(e => e.Id == id);
        }*/
    }
}
