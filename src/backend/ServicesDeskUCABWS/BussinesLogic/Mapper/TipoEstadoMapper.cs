using AutoMapper;
using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Mapper
{
    public class TipoEstadoMapper:Profile
    {
        public TipoEstadoMapper()
        {

            CreateMap<Tipo_Estado, TipoEstadoSearchDTO>();
            CreateMap<TipoEstadoSearchDTO, Tipo_Estado>();

        }
    }
}
