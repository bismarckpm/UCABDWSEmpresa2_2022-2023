using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using Microsoft.AspNetCore.Mvc;


namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public interface ICargoDAO
    {
        List<CargoDTOUpdate> ConsultarCargosDepartamento(Guid IdDepartamento);
        public CargoDTOCreate AgregarCargoDAO(CargoDTOCreate cargo);
        public List<CargoDto> ConsultarCargos();
        public CargoDto ConsultarPorID(Guid id);
        //public CargoDto eliminarCargo(Guid id);
        public CargoDto_Update ActualizarCargo(Cargo cargo);

        CargoDTOUpdate ModificarCargo(CargoDTOUpdate estadoDTOUpdate);
        //public List<CargoDto> GetByIdCargo(Guid idTipo);
        //public List<string> AsignarTipoCargotoCargo(Guid id,string idCargo);
        //public List<CargoDto> DeletedCargo();
        //public List<CargoDto> NoAsociado();

        CargoDTOUpdate HabilitarCargo(Guid Id);
        //public List<string> EditarRelacion(Guid id, string idCargos);

        CargoDTOUpdate DeshabilitarCargo(Guid Id);
        List<CargoDTOUpdate> ConsultarCargosDepartamentoTodos(Guid id);
    }
}
