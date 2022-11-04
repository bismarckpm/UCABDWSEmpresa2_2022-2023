using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;


namespace ServicesDeskUCABWS.Controllers
{

    [Route("Tipo_Ticket")]
    [ApiController]
    public class Tipo_TicketController : ControllerBase
    {

        private readonly ITipo_TicketDAO _TipoTicket;
        private readonly IMapper _mapper;

        private readonly DataContext _TipoTicketContext;


        //CONSTRUCTOR
        public Tipo_TicketController(ITipo_TicketDAO TipoTicket, IMapper mapper)
        {
            _mapper = mapper;
            _TipoTicket = TipoTicket;

        }

        //GET: Controlador para consultar la tipo ticket 
        [HttpGet]
        [Route("Consulta/")]
        public IEnumerable<Tipo_TicketDTO> ConsultarTipoTicketCtrl()
        {

            var tipo = _TipoTicket.ConsultarTipoTicket();
            return tipo;

        }

        /*  [HttpGet]
          [Route("Consulta/(\"{id}\")")]
          public async Task<ActionResult<Tipo_Ticket>> ConsultarTipoTicketGuid(Guid id)
          {
              var tipo = await _TipoTicket.ConsultarTipoTicketGUID(id);


              return tipo;
          }*/

        //GET: Controlador para consultar tipo ticket por un id
        [HttpGet]
        [Route("Consulta/(\"{id}\")")]
        public ActionResult<Tipo_TicketDTO> GetByGuidCtrl(Guid id)
        {
            var plantilla = _TipoTicket.ConsultarTipoTicketGUID(id);

            if (plantilla is null)
                return BadRequest(new { message = $"El ID ({id}) de la URL no coincide con algun ID" });

            var plantillaSearchDTO = _mapper.Map<Tipo_TicketDTO>(plantilla);

            return plantillaSearchDTO;
        }

        //DELETE: Controlador para eliminar tipo ticket
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<Boolean>EliminarTipoTicketCtrl(Guid id)
        {
                var Data = _TipoTicket.EliminarTipoTicket(id).ToString();
                 return true;
        }
         
    }
}
