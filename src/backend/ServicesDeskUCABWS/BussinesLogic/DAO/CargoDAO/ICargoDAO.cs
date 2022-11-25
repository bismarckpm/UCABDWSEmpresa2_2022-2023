using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public interface ICargoDAO
    {
        public CargoDto AgregarCargoDAO(Cargo cargo);
        public List<CargoDto> ConsultarCargos();
        public CargoDto ConsultarPorID(Guid id);
        public CargoDto eliminarCargo(Guid id);
        public CargoDto_Update ActualizarCargo(Cargo cargo);

        public List<CargoDto> GetByIdCargo(Guid idTipo);
        public List<string> AsignarTipoCargotoCargo(Guid id,string idCargo);
        public List<CargoDto> DeletedCargo();
        public List<CargoDto> NoAsociado();

        public List<string> EditarRelacion(Guid id, string idCargos);

    }
}
