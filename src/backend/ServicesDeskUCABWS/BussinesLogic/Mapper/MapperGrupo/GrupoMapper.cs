using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using AutoMapper;
using System;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperGrupo
{
    public class GrupoMapper : Profile
    {

        /// <summary>
        /// Define una forma de acceso de la entidad Grupo a la clase DTO.
        /// Se crea un nuevo identificador, este es utilizado para el registro de nuevos grupos.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo Grupo</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto</returns>

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

        /// <summary>
        /// Define una forma de acceso de la entidad Grupo a la clase DTO.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo Grupo</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto</returns>

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

        /// <summary>
        /// Define una forma de acceso de la clase DTO a la entidad Grupo.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo GrupoDto</param>
        /// <returns>Devuelve un objeto del tipo Grupo</returns>

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

        /// <summary>
        /// Define una forma de acceso de la clase DTO a la entidad Grupo.
        /// Se especifica solo la fecha de modificación.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo GrupoDto_Update</param>
        /// <returns>Devuelve un objeto del tipo Grupo</returns>

        public static Grupo MapperDTOToEntityUpdate(GrupoDto_Update grupo)
        {
            return new Grupo
            {
				id = grupo.id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_ultima_edicion = grupo.fecha_ultima_edicion
            };
        }

        /// <summary>
        /// Define una forma de acceso de la entidad Grupo a la clase DTO.
        /// Se especifica solo la fecha de modificación.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo Grupo</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto_Update</returns>

        public static GrupoDto_Update MapperEntityToDTOUpdate(Grupo grupo)
        {
            return new GrupoDto_Update
            {
                id = grupo.id,
                nombre = grupo.nombre,
                descripcion = grupo.descripcion,
                fecha_ultima_edicion = DateTime.Now.Date
            };
        }
    }
}
