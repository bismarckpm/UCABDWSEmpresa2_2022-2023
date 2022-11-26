using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public class CargoService : ICargoDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        //Constructor
        public CargoService(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public CargoService(IDataContext Context)
        {
            _dataContext = Context;

        }

        public List<CargoDTOUpdate> ConsultarCargosDepartamento(Guid IdDepartamento)
        {
            var lista = new List<CargoDTOUpdate>();
            if (_dataContext.Departamentos.Find(IdDepartamento) != null)
            {
                lista = _mapper.Map<List<CargoDTOUpdate>>(_dataContext.Cargos.Where(x => x.Departamento.id == IdDepartamento).ToList());
            }
            return lista;
        }

        public CargoDTOUpdate ModificarCargo(CargoDTOUpdate cargoDTOUpdate)
        {
            try
            {
                var cargo = _dataContext.Cargos.Find(cargoDTOUpdate.Id);
                if (cargo != null)
                {
                    cargo.nombre_departamental = cargoDTOUpdate.nombre_departamental;
                    cargo.descripcion = cargoDTOUpdate.descripcion;
                    _dataContext.Cargos.Update(cargo);
                    _dataContext.DbContext.SaveChanges();
                    return _mapper.Map<CargoDTOUpdate>(cargo);
                }
                throw new ExceptionsControl("No se encontro el estado a modificar");
            }
            catch (Exception)
            {
                throw new ExceptionsControl("No se pudo modificar el estado por algun error");
            }

        }

        public CargoDTOUpdate DeshabilitarCargo(Guid Id)
        {
            try
            {
                var cargo = _dataContext.Cargos.Find(Id);
                if (cargo != null)
                {
                    cargo.fecha_eliminacion = DateTime.Now;
                    _dataContext.Cargos.Update(cargo);
                    _dataContext.DbContext.SaveChanges();
                    return _mapper.Map<CargoDTOUpdate>(cargo);
                }
                throw new ExceptionsControl("No se encontro el estado a eliminar");
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo habilitar el estado por algun error", ex);
            }
        }

        public CargoDTOUpdate HabilitarCargo(Guid Id)
        {
            try
            {
                var cargo = _dataContext.Cargos.Find(Id);
                if (cargo != null)
                {
                    cargo.fecha_eliminacion = null;
                    _dataContext.Cargos.Update(cargo);
                    _dataContext.DbContext.SaveChanges();
                    return _mapper.Map<CargoDTOUpdate>(cargo);
                }
                throw new ExceptionsControl("No se encontro el estado a eliminar");
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo habilitar el estado por algun error", ex);
            }
        }
    }
}
