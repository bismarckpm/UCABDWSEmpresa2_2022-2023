using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO
{
    public class CargoDAO: ICargoDAO
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;


        //Constructor
        public CargoDAO(DataContext dataContext, IMapper mapeador)
        {
            _dataContext = dataContext;
            _mapper = mapeador;
        }

        //Registrar un Cargo
        public CargoDto AgregarCargoDAO(Cargo cargo)
        {
            try
            {

                _dataContext.Cargos.Add(cargo);
                _dataContext.SaveChanges();

                var nuevoCargo = _dataContext.Cargos.Where(c => c.id == cargo.id)
                                        .Select(c => new CargoDto
                                        {
                                            Id = c.id,
                                            nombre_departamental = c.nombre_departamental,
                                            descripcion = c.descripcion,
                                            fecha_creacion = c.fecha_creacion,
                                            fecha_ultima_edicion = c.fecha_ultima_edicion,
                                            fecha_eliminacion = c.fecha_eliminacion
                                        });

                return nuevoCargo.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }


        }

        //Eliminar un Cargo
        public CargoDto eliminarCargo(Guid id)
        {
            try
            {
                var cargo = _dataContext.Cargos
                .Where(c => c.id == id).First();

                _dataContext.Cargos.Remove(cargo);
                _dataContext.SaveChanges();

                return CargoMapper.MapperEntityToDto(cargo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + id, ex);
            }
        }

        //Actualizar Cargo
        
        public CargoDto_Update ActualizarCargos(Cargo cargo)
        {
            try
            {
                _dataContext.Cargos.Update(cargo);
                _dataContext.SaveChanges();

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + cargo.id, ex);
            }
        }

        //Consultar Cargo por ID
        public CargoDto ConsultarCargoPorID(Guid id)
        {
            var cargo = _dataContext.Cargos
                .Where(c => c.id == id).First();

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
                        Id = c.id,
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

        public CargoDto ConsultarPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public CargoDto_Update CargoDto_Update(Cargo cargo)
        {
            throw new NotImplementedException();
        }
    }
}
