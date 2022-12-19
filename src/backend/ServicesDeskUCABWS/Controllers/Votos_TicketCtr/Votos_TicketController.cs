using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
namespace ServicesDeskUCABWS.Controllers.Votos_TicketCtr
{
    [Route("api/[controller]")]
    [ApiController]
    public class Votos_TicketController : Controller
    {
        private readonly DataContext _context;

        private readonly IVotos_TicketDAO _votos_ticketDAO;

        public Votos_TicketController(IVotos_TicketDAO _votos_ticketDAO, DataContext context, IMapper mapper)
        {
            _context = context;
            this._votos_ticketDAO = _votos_ticketDAO;

        }

        /*public Votos_TicketController(IVotos_TicketDAO _votos_ticketDAO)
        {
            this._votos_ticketDAO = _votos_ticketDAO;

        }*/


        // GET: Votos_Ticket/Details/5
        [HttpGet("Consulta/{id}")]
        public ApplicationResponse<List<Votos_Ticket>> Details([FromRoute]Guid id)
        {
            var response = _votos_ticketDAO.ConsultaVotos(id);

            return response;
        }

    }
}