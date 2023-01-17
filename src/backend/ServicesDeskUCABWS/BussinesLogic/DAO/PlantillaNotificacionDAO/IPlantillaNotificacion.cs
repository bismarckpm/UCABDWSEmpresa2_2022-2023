using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO
{
    public interface IPlantillaNotificacion
    {
        public List<PlantillaNotificacionDTO> ConsultaPlantillas();
        public PlantillaNotificacionDTO ConsultarPlantillaGUID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTitulo(string titulo);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado);
        public PlantillaNotificacionDTO RegistroPlantilla(PlantillaNotificacionDTOCreate plantilla);
        public PlantillaNotificacionDTO ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id);
        public PlantillaNotificacionDTO EliminarPlantilla(Guid id);
        //public Boolean ValidarRelacionPlantillaTipo(Guid tipoEstadoId);
    }
}
