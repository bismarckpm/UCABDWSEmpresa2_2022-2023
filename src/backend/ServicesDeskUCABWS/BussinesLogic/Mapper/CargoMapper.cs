using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class CargoMapper:Profile
    {
        public static CargoDto MapperEntityToDto(Cargo car)
        {
            return new CargoDto
            {
                id = Guid.NewGuid(),
                nombre_departamental = car.nombre_departamental,
                descripcion = car.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static CargoDto MapperEntityToDtoDefault(Cargo car)
        {
            return new CargoDto
            {
                id = Guid.NewGuid(),
                nombre_departamental = car.nombre_departamental,
                descripcion = car.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Cargo MapperDTOToEntity(CargoDto car)
        {
            return new Cargo
            {
                id = Guid.NewGuid(),
                nombre_departamental = car.nombre_departamental,
                descripcion = car.descripcion,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Cargo MapperDTOToEntityModificar(CargoDto_Update car)
        {
            return new Cargo
            {
                id = car.id,
                nombre_departamental = car.nombre_departamental,
                descripcion = car.descripcion,
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = (DateTime)car.fecha_ultima_edicion
            };
        }
    }
}
