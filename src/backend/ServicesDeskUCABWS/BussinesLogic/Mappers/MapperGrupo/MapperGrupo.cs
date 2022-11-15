﻿using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using AutoMapper;
using System;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers.MapperGrupo
{
    public class GrupoMapper : Profile
    {

        public static GrupoDto MapperEntityToDto(Grupo grupo)
        {
            return new GrupoDto
            {
                Id = Guid.NewGuid(),
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static GrupoDto MapperEntityToDtoDefault(Grupo grupo)
        {
            return new GrupoDto()
            {
                Id = grupo.Id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };

        }

        public static Grupo MapperDTOToEntity(GrupoDto grupo)
        {
            return new Grupo(grupo.nombre, grupo.descripcion)
            {
                Id = Guid.NewGuid(),
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = grupo.fecha_creacion
            };
        }

        public static Grupo MapperDTOToEntityModificar(GrupoDto_Update grupo)
        {
            return new Grupo(grupo.nombre, grupo.descripcion)
            {
                Id = grupo.Id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = grupo.fecha_creacion,
                fecha_ultima_edicion = (DateTime)grupo.fecha_ultima_edicion
            };
        }
    }
}