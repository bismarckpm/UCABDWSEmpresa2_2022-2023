using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento
{
    public class DepartamentoMapper : Profile
    {

        /// <summary>
        /// Define una forma de acceso de la entidad Departamento a la clase DTO.
        /// Se crea un nuevo identificador, este es utilizado para el registro de nuevos departamentos.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de la clase departamento</param>
        /// <returns>Retorna un objeto del tipo DepartamentoDto</returns>

        public static DepartamentoDto MapperEntityToDto(Departamento dept)
        {
            return new DepartamentoDto
            {
                Id = Guid.NewGuid(),
                Nombre = dept.nombre,
                Descripcion = dept.descripcion,
                Fecha_creacion = DateTime.Now.Date
            };
        }

        /// <summary>
        /// Define una forma de acceso de la entidad Departamento a la clase DTO.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de la clase departamento</param>
        /// <returns>Retorna un objeto del tipo DepartamentoDto</returns>
        
        public static DepartamentoDto MapperEntityToDtoDefault(Departamento dept)
        {
            return new DepartamentoDto
            {
                Id = dept.id,
                Nombre = dept.nombre,
                Descripcion = dept.descripcion,
                Fecha_creacion = DateTime.Now.Date
            };
        }

        /// <summary>
        /// Define una forma de acceso del DTO a la entidad Departamento.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de la clase departamentoDTO</param>
        /// <returns>Retorna un objeto del tipo Departamento</returns>

        public static Departamento MapperDTOToEntity(DepartamentoDto dept)
        {
            return new Departamento
            {
                id = Guid.NewGuid(),
                nombre = dept.Nombre,
                descripcion = dept.Descripcion,
                fecha_creacion = dept.Fecha_creacion
            };
        }

        /// <summary>
        /// Define una forma de acceso de la clase DTO a la entidad Departamento.
        /// Este es utilizado para la modificación de departamentos.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de la clase DepartamentoDto_Update</param>
        /// <returns>Retorna un objeto del tipo Departamento</returns>

        public static Departamento MapperDTOToEntityModificar(DepartamentoDto_Update dept)
        {
            return new Departamento
            {
                id = dept.Id,
                nombre = dept.Nombre,
                descripcion = dept.Descripcion,
                fecha_creacion = dept.Fecha_creacion,
                fecha_ultima_edicion = dept.Fecha_ultima_edicion,
                id_grupo = dept.Id_grupo
            };
        }

        /// <summary>
        /// Define una forma de acceso de la entidad Departamento a la clase DTO.
        /// Este es utilizado para la modificación de departamentos.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de la clase DepartamentoDto_Update</param>
        /// <returns>Retorna un objeto del tipo Departamento</returns>

        public static DepartamentoDto_Update MapperEntityToDTOModificar(Departamento dept)
        {
            return new DepartamentoDto_Update
            {
                Id = dept.id,
                Nombre = dept.nombre,
                Descripcion = dept.descripcion,
                Fecha_creacion = dept.fecha_creacion,
                Fecha_ultima_edicion = dept.fecha_ultima_edicion
            };
        }
    }
}
