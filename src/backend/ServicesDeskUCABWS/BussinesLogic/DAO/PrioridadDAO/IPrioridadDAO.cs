using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public interface IPrioridadDAO
    {
        public string CrearPrioridad(PrioridadDTO prioridadDTO);
        public List<PrioridadDTO> ObtenerPrioridades();
        public PrioridadDTO ObtenerPrioridadPorNombre(string nombre);
        public List<PrioridadDTO> ObtenerPrioridadesPorEstado(string estado);
        public string ModificarPrioridad(PrioridadDTO prioridadDTO);

    }
}
