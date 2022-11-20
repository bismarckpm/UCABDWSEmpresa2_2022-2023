using AutoMapper;
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
        }
    }
}
