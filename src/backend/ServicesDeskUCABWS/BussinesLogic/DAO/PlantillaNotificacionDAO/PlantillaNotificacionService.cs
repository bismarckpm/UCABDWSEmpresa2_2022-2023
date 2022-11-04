using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO
{
    public class PlantillaNotificacionService : IPlantillaNotificacion
    {
        private readonly IDataContext _plantillaContext;
        private readonly IMapper _mapper;
        private readonly ITipoEstado _tipoEstado;

        public PlantillaNotificacionService(IDataContext plantillaContext, IMapper mapper, ITipoEstado tipoEstado)
        {
            _plantillaContext = plantillaContext;
            _mapper = mapper;
            _tipoEstado = tipoEstado;
        }

        //GET: Servicio para consultar todas las plantillas
        public List<PlantillaNotificacionDTO> ConsultaPlantillas()
        {
            var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta);
            var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionDTO>>(data);
            return plantillaSearchDTO.ToList();
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public PlantillaNotificacionDTO ConsultarPlantillaGUID(Guid id)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Id == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            //catch (SqlException ex)
            //{
            //  throw new ExceptionsControl(Resources.Mensaje, Resource.CodError, ex)
            //}
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese ID", ex);
            }
            
        }

        //GET: Servicio para consultar una plantilla notificacion por un título específico
        public PlantillaNotificacionDTO ConsultarPlantillaTitulo(string titulo)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Titulo == titulo).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }catch(Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
            } 
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado)
        {
            try
            {
                
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstado.nombre == tituloTipoEstado).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla asociada a un tipo estado con ese titulo", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su ID
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoID(Guid id)
        {
            try
            {
                
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstadoId == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese tipo estado", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese tipo estado", ex);
            }
        }

        //POST: Servicio para crear plantilla notificacion
        public Boolean RegistroPlantilla(PlantillaNotificacionDTO plantilla)
        {
            try
            {
                
                //var existeRelacionTipoEstado = 
                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantilla);
                plantillaEntity.Id = Guid.NewGuid();
                if (plantillaEntity.TipoEstado != null)
                {
                    plantillaEntity.TipoEstadoId = plantillaEntity.TipoEstado.Id;
                    plantillaEntity.TipoEstado = null;
                }
                _plantillaContext.PlantillasNotificaciones.Add(plantillaEntity);
                _plantillaContext.DbContext.SaveChanges();

                //
                //Comienza Prueba reemplazo de descripcion plantilla
                var ticket = _plantillaContext.Tickets.Include(t => t.Estado)
                                                      .Include(t => t.Tipo_Ticket)
                                                      .Include(t => t.Prioridad)
                                                      .Include(t => t.Departamento_Destino)
                                                      .ThenInclude(d => d.Grupo).Where(t => t.Id == Guid.Parse("6F5ED7B9-1231-40FF-ACDB-F7291699A228")).Single();

                var reemplazo = ReemplazoEtiqueta(ticket, plantillaEntity.Descripcion);
                Console.WriteLine(reemplazo);

                //Finaliza la prueba
                //
                return true;
            }
            catch(DbUpdateException ex)
            {
                throw new ExceptionsControl("Ya existe una plantilla asociada a ese tipo estado o alguno de los campos de la plantilla está vacia", ex);
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar la plantilla", ex);
            }
        }

        //PUT: Servicio para modificar plantilla notificacion
        public Boolean ActualizarPlantilla(PlantillaNotificacionDTO plantilla, Guid id)
        {
            try
            {

                var plantillaDTO = plantilla;
                plantillaDTO.Id = id;

               // plantillaDTO.TipoEstado = _tipoEstado.ConsultarTipoEstadoGUID(plantillaDTO.TipoEstado.Id);

                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantillaDTO);
                if (plantillaEntity.TipoEstado != null)
                {
                    plantillaEntity.TipoEstado = _mapper.Map<Tipo_Estado>(_tipoEstado.ConsultarTipoEstadoGUID(plantillaDTO.TipoEstado.Id));
                    plantillaEntity.TipoEstadoId = plantillaEntity.TipoEstado.Id;
                }
                //plantillaEntity.TipoEstado = null;
                _plantillaContext.PlantillasNotificaciones.Update(plantillaEntity);
                _plantillaContext.DbContext.SaveChanges();
                return true;
            }
            
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Ya existe una plantilla asociada a ese tipo estado o alguno de los campos de la plantilla está vacia", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar la plantilla", ex);
            }
        }

        //DELETE: Servicio para eliminar plantilla notificacion
        public Boolean EliminarPlantilla(Guid id)
        {
            try
            {
                
                _plantillaContext.PlantillasNotificaciones.Remove(_plantillaContext.PlantillasNotificaciones.Find(id));
                _plantillaContext.DbContext.SaveChanges();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionsControl("No existe ninguna plantilla con el id suministrado", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar la plantilla", ex);
            }
        
        }


        public String ReemplazoEtiqueta(Ticket ticket, string descripciomPlantilla)
        {
            //var usuario = _plantillaContext.Empleados.Include(e => e.Lista_Ticket).Where(t => t.Lista_Ticket.Contains(ticket) == true).Single();
            Dictionary<string, string> etiquetas = new Dictionary<string, string>()
            {
                { "@Ticket", ticket.titulo.ToString() },
                { "@Estado", ticket.Estado.nombre.ToString() },
                { "@Departamento", ticket.Departamento_Destino.nombre.ToString() },
                { "@Grupo", ticket.Departamento_Destino.Grupo.nombre.ToString() },
                { "@Prioridad", ticket.Prioridad.nombre.ToString() },
                //{ "@Cargo", usuario.Cargo.nombre_departamental.ToString() },
                //{ "@Usuario", usuario.primer_nombre.ToString() + usuario.primer_apellido.ToString() },
                { "@TipoTicket", ticket.Tipo_Ticket.nombre.ToString() },
                //{ "@ComentarioVoto" ticket.Votos_Ticket }
            };

            string input = descripciomPlantilla;
            foreach (KeyValuePair<string, string> etiqueta in etiquetas)
            {
                input = Regex.Replace(input, etiqueta.Key, etiqueta.Value);
            }

            return input;
        }


    }
}
