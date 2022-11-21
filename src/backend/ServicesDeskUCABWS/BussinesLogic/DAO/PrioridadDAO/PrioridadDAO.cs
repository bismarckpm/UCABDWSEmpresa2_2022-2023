using AutoMapper;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO
{
    public class PrioridadDAO : IPrioridadDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public PrioridadDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public string CrearPrioridad(PrioridadDTO prioridadDTO)
        {
            try
            {
                var prioridadEntity = _mapper.Map<Prioridad>(prioridadDTO);
                _dataContext.Prioridades.Add(prioridadEntity);
                _dataContext.DbContext.SaveChanges();
                return "Prioridad creada satisfactoriamente";
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo registrar la prioridad", ex);
            }
        }

        public List<PrioridadDTO> ObtenerPrioridades()
        {
            List<Prioridad> data = _dataContext.Prioridades.ToList();
            List<PrioridadDTO> prioridadDTO = _mapper.Map<List<PrioridadDTO>>(data);
            return prioridadDTO;
        }

        public List<PrioridadDTO> ObtenerPrioridadesHabilitadas()
        {
            try
            {
                var data = _dataContext.Prioridades.ToList().Where(p => p.estado == "habilitado").Single();
                var prioridadDTO = _mapper.Map<List<PrioridadDTO>>(data);
                return prioridadDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Algo a sucedido: {ex}");
            }
        }

        public PrioridadDTO ObtenerPrioridad(Guid PrioridadID)
        {
            try
            {
                Prioridad data = _dataContext.Prioridades.AsNoTracking().Where(p => p.Id == PrioridadID).Single();
                PrioridadDTO prioridadDTO = _mapper.Map<PrioridadDTO>(data);
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
                var prioridad = _dataContext.Prioridades.AsNoTracking().Where(p => p.Id == prioridadDTO.Id).Single();
                prioridad.nombre = prioridadDTO.nombre;
                prioridad.descripcion = prioridadDTO.descripcion;
                prioridad.estado = prioridadDTO.estado;
                prioridad.fecha_descripcion = prioridadDTO.fecha_descripcion;
                prioridad.fecha_ultima_edic = prioridadDTO.fecha_ultima_edic;
                _dataContext.Prioridades.Update(prioridad);
                _dataContext.DbContext.SaveChanges();
                return "Prioridad modificada exitosamente";
            }
            catch (Exception ex)
            {
                throw new Exception($"No existe la Prioridad {ex}");
            }
        }
    }
}
