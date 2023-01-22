using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
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
            if (_dataContext.Departamentos.Find(IdDepartamento) != null)
            {
                lista = _mapper.Map<List<EstadoDTOUpdate>>(_dataContext.Estados.Where(x => x.Departamento.id == IdDepartamento).ToList());
            }
            return lista;
        }

        public List<EstadoDTOUpdate> ConsultarEstadosPorEstadoPadre(Guid IdTipoEstado)
        {
            return _mapper.Map<List<EstadoDTOUpdate>>(_dataContext.Estados.Where(e => e.Estado_Padre.Id == IdTipoEstado).ToList());
        }

        //Agregar Estados de los Tipo Estados Agregados
        public void AgregarEstadoATipoEstadoCreado(Tipo_Estado estado)
        {
            var listaEstados = new List<Estado>();

            foreach (var departamento in _dataContext.Departamentos.ToList())
            {
                listaEstados.Add(new Estado(departamento.nombre + " " + estado.nombre, estado.descripcion)
                {
                    Id = Guid.NewGuid(),
                    Departamento = departamento,
                    Estado_Padre = estado,
                    Bitacora_Tickets = new List<Bitacora_Ticket>(),
                    ListaTickets = new List<Ticket>()
                });
            }

            _dataContext.Estados.AddRange(listaEstados);
            //_dataContext.DbContext.SaveChanges();
        }
		

		public EstadoDTOUpdate ModificarEstado(EstadoDTOUpdate estadoDTOUpdate)
        {
            try
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
                throw new ExceptionsControl("No se encontro el estado a modificar");
            }
            catch (Exception)
            {
                throw new ExceptionsControl("No se pudo modificar el estado por algun error");
            }

        }

        public List<EstadoDTOUpdate> ConsultarEstadosDepartamentoTicket(Guid Id)
        {
            var Listaestado = _dataContext.Estados.Include(x => x.Estado_Padre).Include(x => x.Departamento).Where(x => x.Departamento.id == Id
            && (x.Estado_Padre.nombre != "Aprobado" && x.Estado_Padre.nombre != "Rechazado" && x.Estado_Padre.nombre != "Pendiente") || x.fecha_eliminacion==null);

            return _mapper.Map<List<EstadoDTOUpdate>>(Listaestado);

        }

        public EstadoDTOUpdate DeshabilitarEstado(Guid Id)
        {
            try
            {
                var estado = _dataContext.Estados.Find(Id);
                if (estado != null)
                {
                    estado.fecha_eliminacion = DateTime.Now;
                    _dataContext.Estados.Update(estado);
                    _dataContext.DbContext.SaveChanges();
                    return _mapper.Map<EstadoDTOUpdate>(estado);
                }
                throw new ExceptionsControl("No se encontro el estado a eliminar");
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo habilitar el estado por algun error", ex);
            }
        }

        public EstadoDTOUpdate HabilitarEstado(Guid Id)
        {
            try
            {
                var estado = _dataContext.Estados.Find(Id);
                if (estado != null)
                {
                    estado.fecha_eliminacion = null;
                    _dataContext.Estados.Update(estado);
                    _dataContext.DbContext.SaveChanges();
                    return _mapper.Map<EstadoDTOUpdate>(estado);
                }
                throw new ExceptionsControl("No se encontro el estado a habilitar");
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo habilitar el estado por algun error", ex);
            }
        }
    }
}
