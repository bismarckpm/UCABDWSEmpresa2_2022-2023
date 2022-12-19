using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.Entities;
using System.Linq;
using System;
using static ServicesDeskUCABWS.BussinesLogic.Excepciones.PrioridadExcepciones;
using ServicesDeskUCABWS.Data;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones
{
    public class PrioridadValidaciones
    {
        private readonly IDataContext _dataContext;
        public PrioridadValidaciones() { }
        public PrioridadValidaciones(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void validarPrioridad(string nombre, string descripcion, string estado)
        {
            validarPrioridadNombre(nombre);
            validarPrioridadDescripcion(descripcion);
            validarPrioridadEstado(estado);
        }
        public void validarPrioridadGuid(Guid id)
        {
            if (!_dataContext.Prioridades.Any(t => t.Id == id))
                throw new PrioridadNoExisteException("La prioridad no se encuentra registrada en la base de datos");
        }
        public void validarPrioridadNombre(string nombre)
        {
            if (nombre.Length < 3)
                throw new PrioridadNombreLongitudException("El nombre de la excepción no puede ser de longitud menor a 3 caracteres");
        }
        public void validarPrioridadDescripcion(string descripcion)
        {
            if (descripcion.Length < 3 || descripcion.Length > 1000)
                throw new PrioridadDescripcionLongitudException("El formato de la descripción no es el indicado");
        }
        public void validarPrioridadEstado(string estado)
        {
            if (estado != "Habilitado" || estado != "Deshabilitado")
                throw new PrioridadEstadoException("El formato del estado debe ser o Habilitado o Deshabilitado específicamente");
        }
    }
}
