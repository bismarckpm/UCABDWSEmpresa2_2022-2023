using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public interface IPrioridadDAO
    {
        public string CrearPrioridad(PrioridadDTO prioridadDTO);
        public List<PrioridadDTO> ObtenerPrioridades();
        public PrioridadDTO ObtenerPrioridadPorNombre(string nombre);
        public PrioridadDTO ObtenerPrioridad(Guid estado);
        public string ModificarPrioridad(PrioridadDTO prioridadDTO);

    }
}
