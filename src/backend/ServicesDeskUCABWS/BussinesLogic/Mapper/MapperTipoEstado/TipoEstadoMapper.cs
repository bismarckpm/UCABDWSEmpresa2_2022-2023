using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiquetaTipoEstado;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado
{
	public class TipoEstadoMapper : Profile
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

		//TipoEstadoEntity to TipoEstadoDTO
		public static TipoEstadoDTO MapperTipoEstadoEntityToDto(Tipo_Estado tipoEstado)
		{
            return new TipoEstadoDTO
            {
                Id = tipoEstado.Id,
                nombre = tipoEstado.nombre,
                descripcion = tipoEstado.descripcion,
                fecha_eliminacion = tipoEstado.fecha_eliminacion,
                permiso = tipoEstado.permiso,
                etiqueta = EtiquetasByTipoEstado(tipoEstado.etiquetaTipoEstado)
            };
		}

		public static HashSet<EtiquetaDTO> EtiquetasByTipoEstado(HashSet<EtiquetaTipoEstado> etiquetasTipoEstado)
		{
			var etiquetasDTO = new HashSet<EtiquetaDTO>();

			foreach (EtiquetaTipoEstado item in etiquetasTipoEstado)
			{
				var etiqueta = new EtiquetaDTO();
				etiqueta.Id = item.etiqueta.Id;
				etiqueta.Nombre = item.etiqueta.nombre;
				etiqueta.Descripcion = item.etiqueta.descripcion;
				etiquetasDTO.Add(etiqueta);
			}
			return etiquetasDTO;
		}

		public static List<TipoEstadoDTO> MapperListaTipoEstadoEntityToDto(List<Tipo_Estado> tiposEstadosEntity)
		{
			var TipoEstadoDTO = new List<TipoEstadoDTO>();
			foreach (Tipo_Estado item in tiposEstadosEntity)
			{
				TipoEstadoDTO.Add(MapperTipoEstadoEntityToDto(item));
			}
			return TipoEstadoDTO;
		}

		//TipoEstadoDTO to TipoEstadoEntity
		public static Tipo_Estado MapperTipoEstadoDtoToTipoEstadoEntity(TipoEstadoDTO tipoEstadoDTO)
		{
			var tipoEstado =  new Tipo_Estado
			{
				Id = tipoEstadoDTO.Id,
				nombre = tipoEstadoDTO.nombre,
				descripcion = tipoEstadoDTO.descripcion,
				fecha_eliminacion = tipoEstadoDTO.fecha_eliminacion,
				permiso = tipoEstadoDTO.permiso,
				etiquetaTipoEstado = null,
			};
			tipoEstado.etiquetaTipoEstado = EtiquetaTipoEstadoMapper.EtiquetasTipoEstadoByTipoEstadoDTO(tipoEstadoDTO.etiqueta, tipoEstado);
			return tipoEstado;
		}



		//--------------------------------------------------------------------------------------------------------------------------------------------
		//TipoEstadoCreateDTO to TipoEstado
		public static Tipo_Estado MapperTipoEstadoCreateDtoToTipoEstadoEntity(TipoEstadoCreateDTO tipoEstadoDTO)
		{
			var tipoEstado = new Tipo_Estado
			{
				nombre = tipoEstadoDTO.nombre,
				descripcion = tipoEstadoDTO.descripcion,
				permiso = tipoEstadoDTO.permiso,
				etiquetaTipoEstado = null,
			};
			tipoEstado.etiquetaTipoEstado = EtiquetaTipoEstadoMapper.EtiquetasTipoEstadoCreateDtoByTipoEstadoEntity(tipoEstadoDTO.etiqueta, tipoEstado);
			return tipoEstado;
		}
	}
}

