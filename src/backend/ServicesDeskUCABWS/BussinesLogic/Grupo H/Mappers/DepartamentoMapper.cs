using AutoMapper;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers
{
	public class DepartamentoMapper:Profile
	{

		public static DepartamentoDto MapeoEntityDto(Departamento dept)
		{
			return new DepartamentoDto
			{
				Id = Guid.NewGuid(),
				nombre = dept.nombre,
				descripcion = dept.descripcion,
				fecha_creacion = DateTime.Now.Date	
			};
		}
	}
}
