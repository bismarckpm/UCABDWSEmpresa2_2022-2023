using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers
{
    public class TicketMapper: Profile
    {
        public TicketMapper()
        {
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

            CreateMap<TicketDTO, TicketNuevoDTO>();
            CreateMap<TicketNuevoDTO, TicketDTO>();

            CreateMap<TicketDTO, TicketNuevoDTO>();
            CreateMap<TicketNuevoDTO, TicketDTO>();

            CreateMap<Ticket, TicketInfoCompletaDTO>();
            CreateMap<TicketInfoCompletaDTO, Ticket>();
        }
    }
}
