using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
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
