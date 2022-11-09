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
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

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
        public async Task<List<PlantillaNotificacionDTO>> ConsultaPlantillas()
        {
            try
            {
                var data = await _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).ToListAsync();
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionDTO>>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema al consultar las plantillas", ex);
            }

        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public async Task<PlantillaNotificacionDTO> ConsultarPlantillaGUID(Guid id)
        {
            try
            {
                var data = await _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Id == id).SingleAsync();
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
        public async Task<PlantillaNotificacionDTO> ConsultarPlantillaTitulo(string titulo)
        {
            try
            {
                var data = await _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Titulo == titulo).SingleAsync();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }catch(Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
            } 
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        public async Task<PlantillaNotificacionDTO> ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado)
        {
            try
            { 
                var data = await _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstado.nombre == tituloTipoEstado).SingleAsync();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla asociada a un tipo estado con ese titulo", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su ID
        public async Task<PlantillaNotificacionDTO> ConsultarPlantillaTipoEstadoID(Guid id)
        {
            try
            {
                var data = await _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstadoId == id).SingleAsync();
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
        public async Task<Boolean> RegistroPlantilla(PlantillaNotificacionDTOCreate plantilla)
        {
            try
            {
                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantilla);
                plantillaEntity.Id = Guid.NewGuid();
                if (plantillaEntity.TipoEstado != null)
                {
                    plantillaEntity.TipoEstadoId = plantillaEntity.TipoEstado.Id;
                    plantillaEntity.TipoEstado = null;
                }
                _plantillaContext.PlantillasNotificaciones.Add(plantillaEntity);
                await _plantillaContext.DbContext.SaveChangesAsync();

                //
                //Comienza Prueba reemplazo de descripcion plantilla
                //var ticket = _plantillaContext.Tickets.Include(t => t.Estado)
                //                                      .Include(t => t.Tipo_Ticket)
                //                                      .Include(t => t.Prioridad)
                //                                      .Include(t => t.empleado)
                //                                      .Include(t => t.cliente)
                //                                      .Include(t => t.Departamento_Destino)
                //                                      .ThenInclude(d => d.Grupo).Where(t => t.Id == Guid.Parse("6F5ED7B9-1231-40FF-ACDB-F7291699A228")).Single();

                //var reemplazo = ReemplazoEtiqueta(ticket, plantillaEntity.Descripcion);
                //var mail = EnviarCorreo(plantillaEntity.Titulo, reemplazo, "alexguastaferro1@gmail.com");

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
        public async Task<Boolean> ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id)
        {
            try
            {
                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantilla);
                plantillaEntity.Id = id;
                _plantillaContext.PlantillasNotificaciones.Update(plantillaEntity);
                await _plantillaContext.DbContext.SaveChangesAsync();
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
        public async Task<Boolean> EliminarPlantilla(Guid id)
        {
            try
            {
                _plantillaContext.PlantillasNotificaciones.Remove(await _plantillaContext.PlantillasNotificaciones.FindAsync(id));
                await _plantillaContext.DbContext.SaveChangesAsync();
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
            Dictionary<string, string> etiquetas = new Dictionary<string, string>();
            Empleado empleado = null;
            var usuario = _plantillaContext.Usuarios.Where(u => u.Id == ticket.empleado.Id).FirstOrDefault();
            if (usuario == null)
            {
               usuario = _plantillaContext.Usuarios.Where(u => u.Id == ticket.cliente.Id).FirstOrDefault();
            }
            else
            {
                 empleado = _plantillaContext.Empleados.Include(e => e.Cargo).Where(u => u.Id == ticket.empleado.Id).FirstOrDefault();
                etiquetas.Add("@Cargo", empleado.Cargo.nombre_departamental.ToString());
            }
            try 
            {


                etiquetas.Add("@Ticket", ticket.titulo.ToString());
                if (ticket.Estado != null)
                    etiquetas.Add("@Estado", ticket.Estado.nombre.ToString());
                if(ticket.Departamento_Destino != null)
                    etiquetas.Add("@Departamento", ticket.Departamento_Destino.nombre.ToString());
                etiquetas.Add("@Grupo", ticket.Departamento_Destino.Grupo.nombre.ToString());
                etiquetas.Add("@Prioridad", ticket.Prioridad.nombre.ToString());
                etiquetas.Add("@Usuario", usuario.primer_nombre.ToString() + " " + usuario.primer_apellido.ToString());
                etiquetas.Add("@TipoTicket", ticket.Tipo_Ticket.nombre.ToString());

                if (ticket.Votos_Ticket != null)
                    etiquetas.Add("@ComentarioVoto", ticket.Votos_Ticket.ToString()); 
                   

                string input = descripciomPlantilla;
                foreach (KeyValuePair<string, string> etiqueta in etiquetas)
                {
                    input = Regex.Replace(input, etiqueta.Key, etiqueta.Value);
                }

                return input;
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo hacer el reemplazo de las etiquetas en la plantilla", ex);
            }

            
            
        }

        const string correo = "ajguastaferro.13@est.ucab.edu.ve";
        const string clave = "vcrwtnmtilsgjbjo";
        const string alias = "ServiceDeskUCAB";
        const string host = "smtp.gmail.com";
        const int puerto = 587;

        public Boolean EnviarCorreo(string tituloPlantilla, string body, string correoDestino )
        {
            try
            {
                var credenciales = new NetworkCredential(correo, clave);
                var mail = new MailMessage()
                {
                    From = new MailAddress(correo, alias),
                    Subject = tituloPlantilla,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(correoDestino));
                var clienteServidor = new SmtpClient()
                {
                    Host = host,
                    Port = puerto,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };

                clienteServidor.Send(mail);
                return true;
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo enviar el correo", ex);
            }
        }



    }
}
