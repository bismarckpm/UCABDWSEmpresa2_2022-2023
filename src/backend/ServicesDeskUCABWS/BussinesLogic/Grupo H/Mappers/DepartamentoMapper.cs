using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers
{
    public class DepartamentoMapper:Profile
	{

		public static DepartamentoDto MapperEntityToDto(Departamento dept)
		{
			return new DepartamentoDto
			{
				Id = Guid.NewGuid(),
				nombre = dept.nombre,
				descripcion = dept.descripcion,
				fecha_creacion = DateTime.Now.Date	
			};
		}

        public static DepartamentoDto MapperEntityToDtoDefault(Departamento dept)
        {
            return new DepartamentoDto
            {
                Id = dept.id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Departamento MapperDTOToEntity(DepartamentoDto dept)
		{
			return new Departamento
			{
				id = Guid.NewGuid(),
				nombre = dept.nombre,
				descripcion=dept.descripcion,
				fecha_creacion = dept.fecha_creacion
			};
		}

        public static Departamento MapperDTOToEntityModificar(DepartamentoDto_Update dept)
        {
            return new Departamento
            {
                id = dept.Id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion,
                fecha_ultima_edicion = dept.fecha_ultima_edicion
            };
        }
    }
}
