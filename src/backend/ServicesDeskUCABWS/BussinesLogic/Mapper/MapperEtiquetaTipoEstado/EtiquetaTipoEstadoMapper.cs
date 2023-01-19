using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiquetaTipoEstado
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

        public static HashSet<EtiquetaTipoEstado> EtiquetasTipoEstadoByTipoEstadoDTO(HashSet<EtiquetaDTO> etiquetaDTO, Tipo_Estado tipoEstado)
        {
            var etiquetasTipoEstado = new HashSet<EtiquetaTipoEstado>();

            foreach (EtiquetaDTO item in etiquetaDTO)
            {
                var etiquetaTipoEstado = new EtiquetaTipoEstado();
                etiquetaTipoEstado.tipoEstadoID = tipoEstado.Id;
                etiquetaTipoEstado.etiquetaID = item.Id;
                etiquetaTipoEstado.tipoEstado = tipoEstado;
                etiquetaTipoEstado.etiqueta = EtiquetaMapper.MapperEtiquetaDTOToEntity(item);
                etiquetasTipoEstado.Add(etiquetaTipoEstado);
            }
            return etiquetasTipoEstado;
        }

        public static HashSet<EtiquetaTipoEstado> EtiquetasTipoEstadoCreateDtoByTipoEstadoEntity(HashSet<Guid> idEtiquetas, Tipo_Estado tipoEstado)
        {
            var etiquetasTipoEstado = new HashSet<EtiquetaTipoEstado>();

            foreach (Guid item in idEtiquetas)
            {
                var etiquetaTipoEstado = new EtiquetaTipoEstado();
                etiquetaTipoEstado.tipoEstadoID = tipoEstado.Id;
                etiquetaTipoEstado.etiquetaID = item;
                etiquetasTipoEstado.Add(etiquetaTipoEstado);
            }
            return etiquetasTipoEstado;
        }
    }
}
