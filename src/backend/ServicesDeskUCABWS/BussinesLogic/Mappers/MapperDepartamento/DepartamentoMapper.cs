using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers.MapperDepartamento
{
    public class DepartamentoMapper : Profile
    {

        public static DepartamentoDTO MapperEntityToDto(Departamento dept)
        {
            return new DepartamentoDTO
            {
                id = Guid.NewGuid(),
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static DepartamentoDTO MapperEntityToDtoDefault(Departamento dept)
        {
            return new DepartamentoDTO
            {
                id = dept.Id,
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Departamento MapperDTOToEntity(DepartamentoDTO dept)
        {
            return new Departamento
            {
                Id = Guid.NewGuid(),
                nombre = dept.nombre,
                descripcion = dept.descripcion,
                fecha_creacion = dept.fecha_creacion
            };
        }

        public static Departamento MapperDTOToEntityModificar(DepartamentoDTO dept)
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