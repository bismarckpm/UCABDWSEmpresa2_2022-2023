using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using AutoMapper;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers
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
