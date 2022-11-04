using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Models;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class DepartamentoMapper : Profile
    {

        public DepartamentoMapper()
        {
            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();


        }
    }
}
