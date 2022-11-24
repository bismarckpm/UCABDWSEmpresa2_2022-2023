using AutoMapper;
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
    }
}
