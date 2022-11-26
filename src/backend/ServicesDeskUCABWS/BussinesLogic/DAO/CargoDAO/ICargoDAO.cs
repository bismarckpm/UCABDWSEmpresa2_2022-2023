using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public interface ICargoDAO
    {
        List<CargoDTOUpdate> ConsultarCargosDepartamento(Guid IdDepartamento);

        CargoDTOUpdate ModificarCargo(CargoDTOUpdate estadoDTOUpdate);

        CargoDTOUpdate HabilitarCargo(Guid Id);

        CargoDTOUpdate DeshabilitarCargo(Guid Id);
    }
}
