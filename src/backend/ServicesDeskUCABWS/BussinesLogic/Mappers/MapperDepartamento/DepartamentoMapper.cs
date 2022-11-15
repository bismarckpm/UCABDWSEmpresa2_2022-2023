using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers.MapperDepartamento
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
                id = dept.Id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Departamento MapperDTOToEntity(DepartamentoDto dept)
        {
            return new Departamento
            {
                Id = Guid.NewGuid(),
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion
            };
        }

        public static Departamento MapperDTOToEntityModificar(DepartamentoDto_Update dept)
        {
            return new Departamento
            {
                Id = dept.id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion,
                fecha_ultima_edicion = (DateTime)dept.fecha_ultima_edicion,
            };
        }
    }
}