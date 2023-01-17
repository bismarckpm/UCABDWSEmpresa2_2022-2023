using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO
{
    public interface IEstadoDAO
    {
        List<EstadoDTOUpdate> ConsultarEstadosDepartamento(Guid IdDepartamento);

        public List<EstadoDTOUpdate> ConsultarEstadosPorEstadoPadre(Guid IdTipoEstado);

        public void AgregarEstadoATipoEstadoCreado(Tipo_Estado estado);


		EstadoDTOUpdate ModificarEstado(EstadoDTOUpdate estadoDTOUpdate);

        List<EstadoDTOUpdate> ConsultarEstadosDepartamentoTicket(Guid Id);

        public EstadoDTOUpdate HabilitarEstado(Guid Id);

        public EstadoDTOUpdate DeshabilitarEstado(Guid Id);
    }
}
