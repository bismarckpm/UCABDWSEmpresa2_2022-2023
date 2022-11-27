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

        public Tipo_TicketController(ITipo_TicketDAO ticketDAO)
        {
        
            _ticketDAO = ticketDAO;
           

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
        [HttpPut("Editar/{id}")]
        public ApplicationResponse<Tipo_TicketDTOUpdate> EditarTipo_Ticket(Tipo_TicketDTOUpdate tipo_Ticket)
        {
            var response = _ticketDAO.ActualizarTipo_Ticket(tipo_Ticket);
            return response;
        }

        // POST: api/Tipo_Ticket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost]
        [Route("Guardar/")]
        public ApplicationResponse<Tipo_TicketDTOCreate> PostTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTO)
        {
            var response = _ticketDAO.RegistroTipo_Ticket(tipo_TicketDTO);
            return response;
        }

        //GET: Controlador para consultar tipo ticket por un id
        [HttpGet]
        [Route("Consulta/(\"{id}\")")]
        public ApplicationResponse<Tipo_TicketDTOSearch> ConsultarIdTipoTicket(Guid id)

        {
            var response = new ApplicationResponse<Tipo_TicketDTOSearch>();
            try
            {
                response.Data = _ticketDAO.ConsultarTipoTicketGUID(id);
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
        public ApplicationResponse<Tipo_TicketDTOSearch> ConsultarNombreTipoTicket(string nombre)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOSearch>();
            try
            {
              response.Data = _ticketDAO.ConsultarTipoTicketNomb(nombre);

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
        public ApplicationResponse<String> EliminarTipoTicketCtrl(Guid id)
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


     
    }
}
