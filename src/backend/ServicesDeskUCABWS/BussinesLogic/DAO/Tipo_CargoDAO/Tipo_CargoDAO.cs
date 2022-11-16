using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO
{
    public class Tipo_CargoDAO : ITipo_CargoDAO
    {
        private readonly DataContext _dataContext;

        //Constructor
        public Tipo_CargoDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Registrar un Tipo de cargo
        public Tipo_CargoDto AgregarTipo_CargoDAO(Tipo_Cargo tipo)
        {
            try
            {

                _dataContext.Tipos_Cargos.Add(tipo);
                _dataContext.SaveChanges();

                var nuevoTipo_Cargo = _dataContext.Tipos_Cargos.Where(t => t.Id == tipo.Id)
                                        .Select(t => new Tipo_CargoDto
                                        {
                                            Id = t.Id,
                                            descripcion = t.descripcion,
                                            nombre = t.nombre,
                                            fecha_creacion = t.fecha_creacion
                                        });

                return nuevoTipo_Cargo.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Eliminar un TIPO DE CARGO
        public Tipo_CargoDto eliminarTipo_Cargo(Guid id)
        {
            try
            {
                var tipo = _dataContext.Tipos_Cargos
                .Where(t => t.Id == id).First();

                _dataContext.Tipos_Cargos.Remove(tipo);
                _dataContext.SaveChanges();

                return Tipo_CargoMapper.MapperEntityToDto(tipo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + id, ex);
            }
        }

        //Actualizar Tipos de Cargo
        public Tipo_CargoDto_Update actualizarTipo_Cargo(Tipo_Cargo tipo)
        {
            try
            {
                _dataContext.Tipos_Cargos.Update(tipo);
                _dataContext.SaveChanges();

                var data = _dataContext.Tipos_Cargos.Where(t => t.Id == tipo.Id).Select(
                    t => new Tipo_CargoDto_Update
                    {
                        Id = t.Id,
                        nombre = t.nombre,
                        descripcion = t.descripcion,
                        nivel_jerarquia = t.nivel_jerarquia,
                        fecha_ult_edic = t.fecha_ult_edic
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + tipo.Id, ex);
            }
        }

        //Consultar Tipo de Cargo por ID
        public Tipo_CargoDto ConsultarPorID(Guid id)
        {
            var tipo = _dataContext.Tipos_Cargos
                .Where(t => t.Id == id).First();

            return Tipo_CargoMapper.MapperEntityToDtoDefault(tipo);
        }


        //Consultar Tipos de Cargos

        public List<Tipo_CargoDto> ConsultarTipo_Cargos()
        {
            try
            {
                var lista = _dataContext.Tipos_Cargos.Select(
                    t => new Tipo_CargoDto
                    {
                        Id = t.Id,
                        nombre = t.nombre,
                        descripcion = t.descripcion,
                        nivel_jerarquia = t.nivel_jerarquia,
                        fecha_creacion = t.fecha_creacion,
                        fecha_ult_edic = t.fecha_ult_edic,
                        fecha_eliminacion = t.fecha_eliminacion

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

       
    }
}
