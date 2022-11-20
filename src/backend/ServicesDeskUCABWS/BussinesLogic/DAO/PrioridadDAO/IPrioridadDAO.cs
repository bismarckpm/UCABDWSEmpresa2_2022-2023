using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public interface IPrioridadDAO
    {
        public string crearPrioridad(PrioridadDTO prioridadDTO);
        public List<PrioridadDTO> obtenerPrioridades();
        public PrioridadDTO obtenerPrioridadPorNombre(string nombre);
        public List<PrioridadDTO> obtenerPrioridadesPorEstado(string estado);
        public string modificarPrioridad(PrioridadDTO prioridadDTO);

    }
}
