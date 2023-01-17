using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento
{
    public class DepartamentoMapper : Profile
    {

        public static DepartamentoDto MapperEntityToDto(Departamento dept)
        {
            return new DepartamentoDto
            {
                id = Guid.NewGuid(),
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

		public static DepartamentoDto MapperEntityToDtoDefault(Departamento dept)
        {
            return new DepartamentoDto
            {
                id = dept.id,
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
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion
            };
        }

        public static Departamento MapperDTOToEntityModificar(DepartamentoDto_Update dept)
        {
            return new Departamento
            {
                id = dept.id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion,
                fecha_ultima_edicion = dept.fecha_ultima_edicion,
                id_grupo = dept.id_grupo
            };
        }

        public static DepartamentoDto_Update MapperEntityToDTOModificar(Departamento dept)
        {
            return new DepartamentoDto_Update
            {
                id = dept.id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion,
                fecha_ultima_edicion = dept.fecha_ultima_edicion
            };
        }
    }
}
