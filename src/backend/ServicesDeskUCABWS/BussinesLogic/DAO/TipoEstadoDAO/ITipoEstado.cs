using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO
{
    public interface ITipoEstado
    {
        public List<TipoEstadoDTO> ConsultaTipoEstados();
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id);
        public TipoEstadoDTO ConsultarTipoEstadoTitulo(string titulo);
        public Boolean RegistroTipoEstado(TipoEstadoDTO tipoEstado);
        public Boolean ActualizarTipoEstado(TipoEstadoDTO tipoEstadoAct, Guid id);
        public Boolean EliminarTipoEstado(Guid id);
    }
}
