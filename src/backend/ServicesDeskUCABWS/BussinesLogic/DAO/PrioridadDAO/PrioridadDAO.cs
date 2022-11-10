using AutoMapper;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public class PrioridadDAO : IPrioridadDAO
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PrioridadDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public string CrearPrioridad(PrioridadDTO prioridadDTO)
        {
            try
            {
                // var tipoEstadoCreate = tipoEstado;
                // tipoEstadoCreate.etiqueta.Clear(); 
                var prioridadEntity = _mapper.Map<Prioridad>(prioridadDTO);

                _dataContext.Prioridad.Add(prioridadEntity);
                _dataContext.SaveChanges();
                return "Prioridad creada satisfactoriamente";
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar la prioridad", ex);
            }
        }

        public List<PrioridadDTO> ObtenerPrioridades()
        {
            var data = _dataContext.Prioridad.AsNoTracking();
            var prioridadDTO = _mapper.Map<List<PrioridadDTO>>(data);
            return prioridadDTO.ToList();
        }

        public PrioridadDTO ObtenerPrioridadPorNombre(string nombre)
        {
            try
            {
                var data = _dataContext.Prioridad.AsNoTracking().Where(p => p.Nombre == nombre).Single();
                var prioridadDTO = _mapper.Map<PrioridadDTO>(data);
                return prioridadDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"No existe la Prioridad {ex}");
            }
        }

        public List<PrioridadDTO> ObtenerPrioridadesPorEstado(string estado)
        {
            try
            {
                var data = _dataContext.Prioridad.AsNoTracking().Where(p => p.Estado == estado);
                var prioridadDTO = _mapper.Map<List<PrioridadDTO>>(data);
                return prioridadDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"No existe la Prioridad {ex}");
            }
        }

        public string ModificarPrioridad(PrioridadDTO prioridadDTO)
        {
            try
            {
                var prioridad = _dataContext.Prioridad.AsNoTracking().Where(p => p.ID == prioridadDTO.ID).Single();
                prioridad.Nombre = prioridadDTO.Nombre;
                prioridad.Descripcion = prioridadDTO.Descripcion;
                prioridad.Estado = prioridadDTO.Estado;
                prioridad.FechaDescripcion = prioridadDTO.FechaDescripcion;
                prioridad.FechaUltimaEdic = prioridadDTO.FechaUltimaEdic;
                _dataContext.Prioridad.Update(prioridad);
                _dataContext.SaveChanges();
                return "Prioridad modificada exitosamente";
            }
            catch (Exception ex)
            {
                throw new Exception($"No existe la Prioridad {ex}");
            }
        }
    }
}
