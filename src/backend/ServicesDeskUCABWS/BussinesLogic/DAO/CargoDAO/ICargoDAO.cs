using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public interface ICargoDAO
    {
        public CargoDto AgregarCargoDAO(Cargo cargo);
        public List<CargoDto> ConsultarCargos();
        public CargoDto ConsultarPorID(Guid id);
        public CargoDto eliminarCargo(Guid id);
        public CargoDto_Update CargoDto_Update(Cargo cargo);
    }
}
