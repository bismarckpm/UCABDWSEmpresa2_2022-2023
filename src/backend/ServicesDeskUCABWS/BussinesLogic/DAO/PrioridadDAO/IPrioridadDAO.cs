using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public interface IPrioridadDAO
    {
        public string CrearPrioridad(PrioridadSolicitudDTO prioridadDTO);
        public List<PrioridadDTO> ObtenerPrioridades();
        public List<PrioridadDTO> ObtenerPrioridadesHabilitadas();
        public PrioridadDTO ObtenerPrioridad(Guid estado);
        public string ModificarPrioridad(PrioridadDTO prioridadDTO);

    }
}
