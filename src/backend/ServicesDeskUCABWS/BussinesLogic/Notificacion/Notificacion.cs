using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System;
using ServicesDeskUCABWS.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;

namespace ServicesDeskUCABWS.BussinesLogic.Notification
{
    public class Notificacion
    {

        private readonly IDataContext _context;
        const string correo = "servicedeskucab@hotmail.com";
        const string clave = "servicedesk22.";
        const string alias = "ServiceDeskUCAB";
        const string host = "smtp.office365.com";
        const int puerto = 587;

        public Notificacion(IDataContext context)
        {
            _context = context;
        }

        //
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla)
        {
            Dictionary<string, string> etiquetasEstatico = new Dictionary<string, string>();
            Empleado empleado = null;

            var usuario = _context.Usuarios.Where(u => u.Id == ticket.empleado.Id).FirstOrDefault();
            if (usuario == null)
            {
                usuario = _context.Usuarios.Where(u => u.Id == ticket.cliente.Id).FirstOrDefault();
            }
            else
            {
                empleado = _context.Empleados.Include(e => e.Cargo).Where(u => u.Id == ticket.empleado.Id).FirstOrDefault();
                etiquetasEstatico.Add("@Cargo", empleado.Cargo.nombre_departamental.ToString());
            }
            try
            {
                etiquetasEstatico.Add("@Ticket", ticket.titulo.ToString());
                if (ticket.Estado != null)
                    etiquetasEstatico.Add("@Estado", ticket.Estado.nombre.ToString());
                if (ticket.Departamento_Destino != null)
                    etiquetasEstatico.Add("@Departamento", ticket.Departamento_Destino.nombre.ToString());
                etiquetasEstatico.Add("@Grupo", ticket.Departamento_Destino.Grupo.nombre.ToString());
                etiquetasEstatico.Add("@Prioridad", ticket.Prioridad.nombre.ToString());
                etiquetasEstatico.Add("@NombreUsuario", usuario.primer_nombre.ToString() + " " + usuario.primer_apellido.ToString());
                etiquetasEstatico.Add("@TipoTicket", ticket.Tipo_Ticket.nombre.ToString());

                if (ticket.Votos_Ticket != null)
                    etiquetasEstatico.Add("@ComentarioVoto", ticket.Votos_Ticket.ToString());


                string input = Plantilla.Descripcion;
                foreach (EtiquetaDTO etiqueta in Plantilla.TipoEstado.etiqueta)
                {
                    
                    input = Regex.Replace(input, etiqueta.Nombre, etiquetasEstatico.GetValueOrDefault(etiqueta.Nombre));
                }

                return input;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo hacer el reemplazo de las etiquetas en la plantilla", ex);
            }
        }

        //Metodo para hacer el envio del correo
        public Boolean EnviarCorreo(string tituloPlantilla, string body, string correoDestino)
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

                mail.To.Add(correoDestino);
                var clienteServidor = new SmtpClient()
                {
                    Credentials = credenciales,
                    Host = host,
                    Port = puerto,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };


                clienteServidor.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo enviar el correo", ex);
            }
        }
    }
}
