using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinessLogic.Mapper
{
    public class EtiquetaTipoEstadoMapper : Profile
    {
        public EtiquetaTipoEstadoMapper()
        {

            CreateMap<EtiquetaTipoEstado, EtiquetaTipoEstadoDTO>();
            CreateMap<EtiquetaTipoEstadoDTO, EtiquetaTipoEstado>();

            CreateMap<HashSet<EtiquetaTipoEstadoDTO>, HashSet<EtiquetaTipoEstado>>();
            CreateMap<HashSet<EtiquetaTipoEstado>, HashSet<EtiquetaTipoEstadoDTO>>();

        }
    }
}
