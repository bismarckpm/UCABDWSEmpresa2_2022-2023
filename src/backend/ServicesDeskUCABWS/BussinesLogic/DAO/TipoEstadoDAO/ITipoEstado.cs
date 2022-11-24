using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO
{
    public interface ITipoEstado
    {
        public List<TipoEstadoDTO> ConsultaTipoEstados();
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id);
        public TipoEstadoDTO ConsultarTipoEstadoTitulo(string titulo);
        public TipoEstadoCreateDTO RegistroTipoEstado(TipoEstadoCreateDTO tipoEstado);
        public TipoEstadoDTO ActualizarTipoEstado(TipoEstadoUpdateDTO tipoEstadoAct, Guid id);
        public TipoEstadoCreateDTO EliminarTipoEstado(Guid id);
    }
}
