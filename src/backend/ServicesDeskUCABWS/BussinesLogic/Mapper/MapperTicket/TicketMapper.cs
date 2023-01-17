using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTicket
{
    public class TicketMapper : Profile
    {
        public static TicketNuevoDTO MapperTicketToTicketNuevoDTO(Ticket ticket)
        {
            var DTO = new TicketNuevoDTO();
            DTO.titulo = ticket.titulo;
            DTO.descripcion = ticket.descripcion;
            DTO.empleado_id = ticket.Emisor.Id;
            DTO.prioridad_id = ticket.Prioridad.Id;
            DTO.departamentoDestino_Id = ticket.Departamento_Destino.id;
            DTO.tipoTicket_id = ticket.Tipo_Ticket.Id;
            if (ticket.Ticket_Padre != null)
            {
                DTO.ticketPadre_Id = ticket.Ticket_Padre.Id;
            }

            return DTO;
        }
    }
}
