
using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers
{
    public class PrioridadMapper:Profile
    {
        public PrioridadMapper()
        {
            CreateMap<Prioridad, PrioridadDTO>();
            CreateMap<PrioridadDTO,Prioridad>();
        }
    }
}
