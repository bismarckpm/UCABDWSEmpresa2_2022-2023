using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoCargo;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using System.Text.RegularExpressions;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO
{
    public class Tipo_CargoDAO : ITipo_CargoDAO
    {
        private readonly IDataContext _dataContext;

        //Constructor
        public Tipo_CargoDAO(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        private bool ExisteTipoCargo(Tipo_Cargo tipo)
        {
            bool existe = false;

            try
            {
                var nuevoTipoCargo = _dataContext.Tipos_Cargos.Where(d => d.nombre.Equals(tipo.nombre));
                if (nuevoTipoCargo.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El Tipo de cargo" + tipo.id + "ya está registrado", ex);
            }
            return existe;
        }

        //Registrar un Tipo de cargo
        public Tipo_CargoDto AgregarTipo_CargoDAO(Tipo_Cargo tipo)
        {

            try
            {

                if (ExisteTipoCargo(tipo) == false)
                {

                    _dataContext.Tipos_Cargos.Add(tipo);
                    _dataContext.DbContext.SaveChanges();
                }




                var nuevoTipoCargo = _dataContext.Tipos_Cargos.Where(d => d.id == tipo.id)
                        .Select(d => new Tipo_CargoDto
                        {
                            id = d.id,
                            nombre = d.nombre,
                            descripcion = d.descripcion,
                            fecha_creacion = d.fecha_creacion

                        }).First();

                return nuevoTipoCargo;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el cargo" + " " + tipo.nombre, ex);
            }

        }


        //Eliminar un TIPO DE CARGO


        //Actualizar Tipos de Cargo
        public Tipo_CargoDto_Update actualizarTipo_Cargo(Tipo_Cargo tipo)
        {
            try
            {
                _dataContext.Tipos_Cargos.Update(tipo);
                _dataContext.DbContext.SaveChanges();

                var data = _dataContext.Tipos_Cargos.Where(t => t.id == tipo.id).Select(
                    t => new Tipo_CargoDto_Update
                    {
                        id = t.id,
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
                throw new Exception("Fallo al actualizar: " + tipo.id, ex);
            }
        }

        //Consultar Tipo de Cargo por ID
        public Tipo_CargoDto ConsultarPorID(Guid id)
        {
            try
            {
                var tipo = _dataContext.Tipos_Cargos
                            .Where(d => d.id == id).First();

                return Tipo_CargoMapper.MapperEntityToDtoDefault(tipo);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El tipo de cargo" + id + "No esta registrado", ex);
            }
        }


        //Consultar Tipos de Cargos

        public List<Tipo_CargoDto> ConsultarTipo_Cargos()
        {
            try
            {
                var lista = _dataContext.Tipos_Cargos.Select(
                    t => new Tipo_CargoDto
                    {
                        id = t.id,
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
        public bool QuitarAsociacion(Guid tipoId)
        {
            var listaTipo = _dataContext.Cargos.Where(x => x.id_tipo == tipoId);

            if (listaTipo != null)
            {

                foreach (var item in listaTipo)
                {
                    item.id_tipo = null;

                }
                _dataContext.DbContext.SaveChanges();
                return true;

            }
            return false;


        }

        public Tipo_CargoDto EliminarTipo_Cargo(Guid id)
        {
            try
            {
                var tipo = _dataContext.Tipos_Cargos
                           .Where(d => d.id == id).First();


                tipo.fecha_eliminacion = DateTime.Now.Date;

                _dataContext.DbContext.SaveChanges();

                return Tipo_CargoMapper.MapperEntityToDto(tipo);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el cargo" + " " + id, ex);
            }
        }

        public List<Tipo_CargoDto> ConsultarGrupoNoEliminado()
        {
            try
            {
                var lista = _dataContext.Tipos_Cargos.Where(x => x.fecha_eliminacion == null).Select(
                    d => new Tipo_CargoDto
                    {
                        id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,                        
                        fecha_eliminacion = d.fecha_eliminacion

                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay grupos registrados", ex);
            }
        }
        private bool ExisteTipo(Tipo_Cargo tipo)
        {
            bool existe = false;

            try
            {
                var nuevoTipo = _dataContext.Tipos_Cargos.Where(d => d.nombre.Equals(tipo.nombre));
                if (nuevoTipo.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El grupo" + tipo.nombre + "ya está registrado", ex);
            }
            return existe;
        }

        public Tipo_CargoDto UltimoTipoRegistradoDao()
        {
            try
            {
                var tipo = _dataContext.Tipos_Cargos.OrderBy(x => x.id).LastOrDefault();

                return Tipo_CargoMapper.MapperEntityToDtoDefault(tipo);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay tipo registrado", ex);
            }
        }



    }
}
