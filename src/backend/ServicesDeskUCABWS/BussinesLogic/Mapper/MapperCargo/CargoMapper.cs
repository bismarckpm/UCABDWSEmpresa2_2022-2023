using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo
{
    public class CargoMapper : Profile
    {
        public static CargoDto MapperEntityToDto(Cargo cargo)
        {
            return new CargoDto
            {
                id = Guid.NewGuid(),
                nombre_departamental = cargo.nombre_departamental,
                descripcion = cargo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static CargoDto MapperEntityToDtoDefault(Cargo cargo)
        {
            return new CargoDto
            {
                id = cargo.id,
                nombre_departamental = cargo.nombre_departamental,
                descripcion = cargo.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Cargo MapperDTOToEntity(CargoDto cargo)
        {
            return new Cargo
            {
                id = Guid.NewGuid(),
                nombre_departamental = cargo.nombre_departamental,
                descripcion = cargo.descripcion,
                fecha_creacion = cargo.fecha_creacion
            };
        }

        public static Cargo MapperDTOToEntityModificar(CargoDto_Update cargo)
        {
            return new Cargo
            {
                id = cargo.id,
                nombre_departamental = cargo.nombre_departamental,
                descripcion = cargo.descripcion,
                fecha_creacion = cargo.fecha_creacion,
                fecha_ultima_edicion = (DateTime)cargo.fecha_ultima_edicion,
                id_tipo = cargo.id_tipo
            };
        }
    }
}
