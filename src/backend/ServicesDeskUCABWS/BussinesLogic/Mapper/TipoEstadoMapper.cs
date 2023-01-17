using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class TipoEstadoMapper:Profile
    {
        public TipoEstadoMapper()
        {

            CreateMap<Tipo_Estado, TipoEstadoDTO>()
                .ForMember(dto => dto.etiqueta, opt => opt.MapFrom(x => x.etiquetaTipoEstado.Select(y => y.etiqueta).ToList())); 
            CreateMap<TipoEstadoDTO, Tipo_Estado>();
            CreateMap<Tipo_Estado, TipoEstadoCreateDTO>()
                .ForMember(dto => dto.etiqueta, opt => opt.MapFrom(x => x.etiquetaTipoEstado.Select(y => y.etiqueta).ToList()));

            CreateMap<TipoEstadoCreateDTO, Tipo_Estado>();
            CreateMap<Tipo_Estado, TipoEstadoCreateDTO>();

            CreateMap<TipoEstadoUpdateDTO, Tipo_Estado>();
            CreateMap<Tipo_Estado, TipoEstadoUpdateDTO>();

        }
    }
}
