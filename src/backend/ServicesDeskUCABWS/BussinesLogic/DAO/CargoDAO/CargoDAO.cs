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


namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public class CargoDAO: ICargoDAO
    {

        private readonly DataContext _dataContext;
       // private readonly IMapper _mapper;
        private readonly ITipo_CargoDAO _servicioTipo;


        //Constructor
        public CargoDAO(DataContext dataContext, ITipo_CargoDAO servicioTipo)
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

                if (ExisteCargo(cargo) == false) {

                    _dataContext.Cargos.Add(cargo);
                    _dataContext.SaveChanges();
                }          

                    
                

                var nuevoCargo = _dataContext.Cargos.Where(d => d.Id == cargo.Id)
                        .Select(d => new CargoDto
                        {
                            Id = d.Id,
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
                           .Where(d => d.Id == id).First();


                cargo.fecha_eliminacion = DateTime.Now.Date;
                cargo.id_tipo = null;
                _dataContext.SaveChanges();

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
                _dataContext.SaveChanges();

                var data = _dataContext.Cargos.Where(c => c.Id == cargo.Id).Select(
                    c => new CargoDto_Update
                    {
                        id = c.Id,
                        nombre_departamental = c.nombre_departamental,
                        descripcion = c.descripcion,
                        fecha_creacion = c.fecha_creacion,
                        fecha_ultima_edicion = c.fecha_ultima_edicion,
                        fecha_eliminacion = c.fecha_eliminacion
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + cargo.Id, ex);
            }
        }

        //Consultar Cargo por ID
        public CargoDto ConsultarPorID(Guid id)
        {
            var cargo = _dataContext.Cargos
                .Where(c => c.Id == id).First();

            return CargoMapper.MapperEntityToDtoDefault(cargo);
        }


        //Consultar Cargo

        public List<CargoDto> ConsultarCargos()
        {
            try
            {
                var lista = _dataContext.Cargos.Select(
                    c => new CargoDto
                    {
                        Id = c.Id,
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
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
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
                        Id = d.Id,
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
                            Id = d.Id,
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

                    var nuevoCargo = _dataContext.Cargos.Where(d => d.Id.ToString() == cargo).FirstOrDefault();
                    nuevoCargo.id_tipo = id;
                    _dataContext.SaveChanges();

                }

                return listaCargo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new ExceptionsControl("Fallo al asignar grupo: al cargo" + idCargo, ex);
            }
        }

        

        private bool ExisteCargo(Cargo cargo)
        {
            bool existe = false;

            try
            {
                var nuevoCargo = _dataContext.Cargos.Where(d => d.nombre_departamental.Equals(cargo.nombre_departamental));
                if (nuevoCargo.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El Cargo" + cargo.Id + "ya está registrado", ex);
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
                        Id = d.Id,
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

                        var relacionado = _dataContext.Cargos.Where(x => x.Id.ToString() == nuevoCargo).FirstOrDefault();
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
