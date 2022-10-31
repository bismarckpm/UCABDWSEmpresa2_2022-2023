using AutoMapper;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
	public class GrupoMapper:Profile
	{
		public static GrupoDto MapperEntityDto(GrupoDto grupDto)
		{
			return grupDto = new GrupoDto()
			{
				Id = Guid.NewGuid(),
				nombre = grupDto.nombre,
				descripcion = grupDto.descripcion,
				fecha_creacion = DateTime.Now.Date
			};

		}
	}
}
