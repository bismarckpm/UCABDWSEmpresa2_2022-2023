using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoCargo
{
    public class Tipo_CargoMapper : Profile
    {

        public static Tipo_CargoDto MapperEntityToDto(Tipo_Cargo tipo)
        {
            return new Tipo_CargoDto
            {
                id = Guid.NewGuid(),
                nombre = tipo.nombre,
                descripcion = tipo.descripcion,
                nivel_jerarquia = tipo.nivel_jerarquia,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Tipo_CargoDto MapperEntityToDtoDefault(Tipo_Cargo tipo)
        {
            return new Tipo_CargoDto
            {
                id = tipo.id,
                nombre = tipo.nombre,
                descripcion = tipo.descripcion,
                nivel_jerarquia = tipo.nivel_jerarquia,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Tipo_Cargo MapperDTOToEntity(Tipo_CargoDto tipo)
        {
            return new Tipo_Cargo
            {
                id = Guid.NewGuid(),
                nombre = tipo.nombre,
                descripcion = tipo.descripcion,
                nivel_jerarquia = tipo.nivel_jerarquia,
                fecha_creacion = tipo.fecha_creacion,
            };
        }

        public static Tipo_Cargo MapperDTOToEntityModificar(Tipo_CargoDto_Update tipo)
        {
            return new Tipo_Cargo
            {
                id = tipo.id,
                nombre = tipo.nombre,
                descripcion = tipo.descripcion,
                nivel_jerarquia = tipo.nivel_jerarquia,
                fecha_ult_edic = (DateTime)tipo.fecha_ult_edic

            };
        }

    }
}
