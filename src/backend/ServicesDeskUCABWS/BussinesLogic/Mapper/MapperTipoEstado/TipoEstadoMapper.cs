using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using System.Linq;

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
			tipoEstado.etiquetaTipoEstado = EtiquetasTipoEstadoByTipoEstadoDTO(tipoEstadoDTO.etiqueta, tipoEstado);
			return tipoEstado;
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
			tipoEstado.etiquetaTipoEstado = EtiquetasTipoEstadoCreateDtoByTipoEstadoEntity(tipoEstadoDTO.etiqueta, tipoEstado);
			return tipoEstado;
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

