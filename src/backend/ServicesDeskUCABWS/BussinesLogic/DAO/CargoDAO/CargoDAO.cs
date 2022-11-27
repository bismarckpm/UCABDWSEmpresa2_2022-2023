using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using Microsoft.EntityFrameworkCore;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public class CargoDAO: ICargoDAO
    {

        private readonly IDataContext _dataContext;
       // private readonly IMapper _mapper;
        private readonly ITipo_CargoDAO _servicioTipo;


        //Constructor
        public CargoDAO(IDataContext dataContext, ITipo_CargoDAO servicioTipo)
        {
            _dataContext = dataContext;
            _servicioTipo = servicioTipo;
            // _mapper = mapeador;
        }

        //Registrar un Cargo
        public CargoDto AgregarCargoDAO(Cargo cargo)
        {
            
            try
            {

                if (!ExisteCargo(cargo)) {

                    _dataContext.Cargos.Add(cargo);
                    _dataContext.DbContext.SaveChanges();
                }   

                var nuevoCargo = _dataContext.Cargos.Where(d => d.id == cargo.id)
                        .Select(d => new CargoDto
                        {
                            id = d.id,
                            nombre_departamental = d.nombre_departamental,
                            descripcion = d.descripcion,
                            fecha_creacion = d.fecha_creacion

                        }).First();

                return nuevoCargo;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el cargo" + " " + cargo.nombre_departamental, ex);
            }

        }

        //Eliminar un Cargo
        
        public CargoDto eliminarCargo(Guid id)
        {
            try
            {
                var cargo = _dataContext.Cargos
                           .Where(d => d.id == id).First();


                cargo.fecha_eliminacion = DateTime.Now.Date;
                cargo.id_tipo = null;
                _dataContext.DbContext.SaveChanges();

                return CargoMapper.MapperEntityToDto(cargo);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el cargo" + " " + id, ex);
            }
        }

        //Actualizar Cargo

        public CargoDto_Update ActualizarCargo(Cargo cargo)
        {
            try
            {
                _dataContext.Cargos.Update(cargo);
                _dataContext.DbContext.SaveChanges();

                var data = _dataContext.Cargos.Where(c => c.id == cargo.id).Select(
                    c => new CargoDto_Update
                    {
                        id = c.id,
                        nombre_departamental = c.nombre_departamental,
                        descripcion = c.descripcion,
                        fecha_creacion = c.fecha_creacion,
                        fecha_ultima_edicion = c.fecha_ultima_edicion,
                        fecha_eliminacion = c.fecha_eliminacion
                    }

                );
                return data.First();
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Fallo al actualizar el cargo: " + cargo.nombre_departamental, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el cargo" + " " + cargo.id, ex);
            }
        }

        //Consultar Cargo por ID
        public CargoDto ConsultarPorID(Guid id)
        {
            try
            {
                var cargo = _dataContext.Cargos
               .Where(c => c.id == id).First();

                return CargoMapper.MapperEntityToDtoDefault(cargo);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el Grupo" + " " + id, ex);
            }

        }


        //Consultar Cargo

        public List<CargoDto> ConsultarCargos()
        {
            try
            {
                var lista = _dataContext.Cargos.Select(
                    c => new CargoDto
                    {
                        id = c.id,
                        nombre_departamental = c.nombre_departamental,
                        descripcion = c.descripcion,
                        fecha_creacion = c.fecha_creacion,
                        fecha_ultima_edicion = c.fecha_ultima_edicion,
                        fecha_eliminacion = c.fecha_eliminacion
                    }

                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay cargos registrados", ex);
            }
        }

        //Retorna una lista de departamentos que no están eliminados
        public List<CargoDto> DeletedCargo()
        {
            try
            {
                var lista = _dataContext.Cargos.Where(x => x.fecha_eliminacion == null).Select(
                    d => new CargoDto
                    {
                        id = d.id,
                        nombre_departamental = d.nombre_departamental,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion,
                        fecha_eliminacion = d.fecha_eliminacion

                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay departamentos eliminados", ex);
            }
        }


        //Listar departamentos por el identificador de un grupo
        public List<CargoDto> GetByIdCargo(Guid idTipo)
        {
            try
            {

                var cargos = _dataContext.Cargos.Where(tipo => tipo.id_tipo == idTipo).Select(
                        d => new CargoDto
                        {
                            id = d.id,
                            nombre_departamental = d.nombre_departamental,
                            descripcion = d.descripcion,
                            fecha_creacion = d.fecha_creacion,
                            fecha_ultima_edicion = d.fecha_ultima_edicion,
                            fecha_eliminacion = d.fecha_eliminacion
                        }
                     );
                return cargos.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El Cargo" + idTipo + "No esta registrado", ex);
            }
        }


        public List<string> AsignarTipoCargotoCargo(Guid id, string idCargo)
        {

            try
            {
                List<string> listaCargo = idCargo.Split(',').ToList();
                


                foreach (var cargo in listaCargo)
                {

                    var nuevoCargo = _dataContext.Cargos.Where(d => d.id.ToString() == cargo).FirstOrDefault();
                    nuevoCargo.id_tipo = id;
                    _dataContext.DbContext.SaveChanges();

                }

                return listaCargo;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al asignar cargo", ex);
            }
        }

        

        public bool ExisteCargo(Cargo cargo)
        {
            bool existe = false;

            try
            {
                var nuevoCargo = _dataContext.Cargos.Where(d => d.nombre_departamental.Equals(cargo.nombre_departamental ) && d.fecha_eliminacion == null);
                if (nuevoCargo.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El cargo" + cargo.id + "ya está registrado", ex);
            }
            return existe;
        }


        //Retorna una lista de departamentos que no están asociados a un grupo
        public List<CargoDto> NoAsociado()
        {
            try
            {
                var lista = _dataContext.Cargos.Where(x => x.id_tipo == null).Select(
                    d => new CargoDto
                    {
                        id = d.id,
                        nombre_departamental = d.nombre_departamental,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion,
                        fecha_eliminacion = d.fecha_eliminacion
                    }
                );
                return lista.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay departamentos registrados", ex);
            }
        }


        public List<string> EditarRelacion(Guid id, string idCargos)
        {
            try
            {
                List<string> listaCargo = idCargos.Split(',').ToList();

                if (idCargos.Equals(""))
                {

                    _servicioTipo.QuitarAsociacion(id);

                    return listaCargo;

                }
                else if (_servicioTipo.QuitarAsociacion(id))
                {

                    foreach (var nuevoCargo in listaCargo)
                    {

                        var relacionado = _dataContext.Cargos.Where(x => x.id.ToString() == nuevoCargo).FirstOrDefault();
                        if (relacionado != null){
                            relacionado.id_tipo = id;
                            relacionado.fecha_ultima_edicion = DateTime.Now.Date;
                            _dataContext.DbContext.SaveChanges();
                        }

                    }

                }
                return listaCargo;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al asignar tipo de cargo", ex);
            }
        }








    }






}
