using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using AutoMapper;
using System;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperGrupo
{
    public class GrupoMapper : Profile
    {

        public static GrupoDto MapperEntityToDto(Grupo grupo)
        {
            return new GrupoDto
            {
                id = Guid.NewGuid(),
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static GrupoDto MapperEntityToDtoDefault(Grupo grupo)
        {
            return new GrupoDto()
            {
                id = grupo.id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };

        }

        public static Grupo MapperDTOToEntity(GrupoDto grupo)
        {
            return new Grupo
            {
				id = Guid.NewGuid(),
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_creacion = grupo.fecha_creacion
            };
        }

        public static Grupo MapperDTOToEntityModificar(GrupoDto_Update grupo)
        {
            return new Grupo
            {
				id = grupo.Id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_ultima_edicion = grupo.fecha_ultima_edicion
            };
        }
    }
}
