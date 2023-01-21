using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperPlantillaNotificacion
{
    public class PlantillaNotificacionMapper : Profile
    {
        public PlantillaNotificacionMapper()
        {

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTO>();
            CreateMap<PlantillaNotificacionDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTOCreate>();
            CreateMap<PlantillaNotificacionDTOCreate, PlantillaNotificacion>();

        }

		//PlantillaNotificacionEntity To PlantillaNotificacionDTO
		public static PlantillaNotificacionDTO MapperPlantillaEntityToPlantillaDto(PlantillaNotificacion plantilla)
		{
			var plantillaDTO = new PlantillaNotificacionDTO();
			plantillaDTO.Id = plantilla.Id;
			plantillaDTO.Titulo = plantilla.Titulo;
			plantillaDTO.Descripcion = plantilla.Descripcion;
			if (plantilla.TipoEstado != null)
			{
				plantillaDTO.TipoEstado = TipoEstadoMapper.MapperTipoEstadoEntityToDto(plantilla.TipoEstado);
			}
			return plantillaDTO;
		}

		//PlantillaNotificacionDTO To PlantillaNotificacionEntity
		public static PlantillaNotificacion MapperPlantillaDtoToPlantillaEntity(PlantillaNotificacionDTO plantillaDto)
		{
			var plantillaEntity = new PlantillaNotificacion();
			plantillaEntity.Id = plantillaDto.Id;
			plantillaEntity.Titulo = plantillaDto.Titulo;
			plantillaEntity.Descripcion = plantillaDto.Descripcion;
			if (plantillaDto.TipoEstado != null)
			{
				plantillaEntity.TipoEstado = TipoEstadoMapper.MapperTipoEstadoDtoToTipoEstadoEntity(plantillaDto.TipoEstado);
			}
			return plantillaEntity;
		}

		//List<PlantillaNotificacionEntity> To List<PlantillaNotificacionDTO>
		public static List<PlantillaNotificacionDTO> MapperListaPlantillaEntityToPlantillaDto(List<PlantillaNotificacion> plantillasEntity)
		{
			var plantillaDTO = new List<PlantillaNotificacionDTO>();
			foreach (PlantillaNotificacion item in plantillasEntity)
			{
				plantillaDTO.Add(MapperPlantillaEntityToPlantillaDto(item));
			}
			return plantillaDTO;
		}

		//PlantillaNotificacionDTOCreate To PlantillaNotificacionEntity 
		public static PlantillaNotificacion MapperPlantillaCreateDtoToPlantillaEntity(PlantillaNotificacionDTOCreate plantillaCreateDto)
		{
			var plantillaEntity = new PlantillaNotificacion();
			plantillaEntity.Titulo = plantillaCreateDto.Titulo;
			plantillaEntity.Descripcion = plantillaCreateDto.Descripcion;
			plantillaEntity.TipoEstadoId = plantillaCreateDto.TipoEstadoId;

			return plantillaEntity;
		}
	}
}
