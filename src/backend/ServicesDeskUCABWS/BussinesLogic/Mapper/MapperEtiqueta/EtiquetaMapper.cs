using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta
{
	public class EtiquetaMapper : Profile
	{

		public EtiquetaMapper()
		{
			CreateMap<Etiqueta, EtiquetaDTO>();
			CreateMap<EtiquetaDTO, Etiqueta>();
		}

		public static EtiquetaDTO MapperEtiquetaEntityToDto(Etiqueta etiqueta)
		{
			return new EtiquetaDTO
			{
				Id = etiqueta.Id,
				Nombre = etiqueta.nombre,
				Descripcion = etiqueta.descripcion,
			};
		}

		public static Etiqueta MapperEtiquetaDTOToEntity(EtiquetaDTO etiquetaDto)
		{
			return new Etiqueta
			{
				Id = etiquetaDto.Id,
				nombre = etiquetaDto.Nombre,
				descripcion = etiquetaDto.Descripcion,
				etiquetaTipoEstado = null,
			};
		}
	}
}
