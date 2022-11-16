using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class Tipo_CargoMapper : Profile
    {

        public static Tipo_CargoDto MapperEntityToDto(Tipo_Cargo tip)
        {
            return new Tipo_CargoDto
            {
                Id = Guid.NewGuid(),
                nombre = tip.nombre,
                descripcion = tip.descripcion,
                nivel_jerarquia = tip.nivel_jerarquia,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Tipo_CargoDto MapperEntityToDtoDefault(Tipo_Cargo tip)
        {
            return new Tipo_CargoDto
            {
                Id = tip.Id,
                nombre = tip.nombre,
                descripcion = tip.descripcion,
                nivel_jerarquia = tip.nivel_jerarquia,
                fecha_creacion = DateTime.Now.Date
            };
        }

        public static Tipo_Cargo MapperDTOToEntity(Tipo_CargoDto tip)
        {
            return new Tipo_Cargo
            {
                Id = Guid.NewGuid(),
                nombre = tip.nombre,
                descripcion = tip.descripcion,
                nivel_jerarquia = tip.nivel_jerarquia,
                fecha_creacion = tip.fecha_creacion,
            };
        }

        public static Tipo_Cargo MapperDTOToEntityModificar(Tipo_CargoDto_Update tip)
        {
            return new Tipo_Cargo
            {
                Id = tip.Id,
                nombre = tip.nombre,
                descripcion = tip.descripcion,
                nivel_jerarquia = tip.nivel_jerarquia,               
                fecha_ult_edic = (DateTime)tip.fecha_ult_edic

            };
        }

    }
}
