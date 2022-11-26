using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO
{
    public class EstadoService : IEstadoDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        //Constructor
        public EstadoService(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public EstadoService(IDataContext Context)
        {
            _dataContext = Context;

        }

        public List<EstadoDTOUpdate> ConsultarEstadosDepartamento(Guid IdDepartamento)
        {
            var lista = new List<EstadoDTOUpdate>();
            if (_dataContext.Departamentos.Find(IdDepartamento)!=null)
            {
                lista = _mapper.Map<List<EstadoDTOUpdate>>(_dataContext.Estados.Where(x => x.Departamento.id == IdDepartamento).ToList());
            }
            return lista;
        }

        public EstadoDTOUpdate ModificarEstado(EstadoDTOUpdate estadoDTOUpdate)
        {
            var estado = _dataContext.Estados.Find(estadoDTOUpdate.Id);
            if (estado != null)
            {
                estado.nombre = estadoDTOUpdate.nombre;
                estado.descripcion = estadoDTOUpdate.descripcion;
                _dataContext.Estados.Update(estado);
                _dataContext.DbContext.SaveChanges();
                return _mapper.Map<EstadoDTOUpdate>(estado);
            }
            return null;
        }

        public List<EstadoDTOSearch> ConsultarEstadosDepartamentoTicket(Guid Id)
        {
            var Listaestado = _dataContext.Estados.Include(x=>x.Estado_Padre).Include(x=>x.Departamento).Where(x=>x.Departamento.id==Id 
            && (x.Estado_Padre.nombre != "Aprobado" && x.Estado_Padre.nombre != "Rechazado" && x.Estado_Padre.nombre != "Pendiente"));
            
            return _mapper.Map<List<EstadoDTOSearch>>(Listaestado);
            
        }
    }
}
