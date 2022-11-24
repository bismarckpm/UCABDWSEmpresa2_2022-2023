using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public class NotificacionService : INotificacion
    {
        private readonly IDataContext _context;
        const string correo = "servicedeskucab@hotmail.com";
        const string clave = "servicedesk22.";
        const string alias = "ServiceDeskUCAB";
        const string host = "smtp.office365.com";
        const int puerto = 587;

        public NotificacionService(IDataContext context)
        {
            _context = context;
        }

        //Servicio para reeemplazar las etiquetas de la plantilla notificación
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla)
        {
            Dictionary<string, string> etiquetasEstatico = new Dictionary<string, string>();
            
            //Empleado empleado = null;
            //var cliente = _context.Clientes.Where(u => u.Id == ticket.cliente.Id).FirstOrDefault();
            //var empleados = _context.Empleados.Where(u => u.Id == ticket.empleado.Id).FirstOrDefault();

            try
            {
                /*if (ticket.Emisor != null)
                {*/
                    etiquetasEstatico.Add("@Cargo", ticket.Emisor.Cargo.nombre_departamental.ToString());
                    etiquetasEstatico.Add("@Usuario", ticket.Emisor.primer_nombre.ToString() + " " + ticket.Emisor.primer_apellido.ToString());
                /*}
                else
                {
                    etiquetasEstatico.Add("@Usuario", ticket.cliente.primer_nombre.ToString() + " " + ticket.cliente.primer_apellido.ToString());
                }*/

                etiquetasEstatico.Add("@Ticket", ticket.titulo.ToString());
                if (ticket.Estado != null)
                    etiquetasEstatico.Add("@Estado", ticket.Estado.nombre.ToString());
                if (ticket.Departamento_Destino != null)
                    etiquetasEstatico.Add("@Departamento", ticket.Departamento_Destino.nombre.ToString());
                etiquetasEstatico.Add("@Grupo", ticket.Departamento_Destino.grupo.nombre.ToString());
                etiquetasEstatico.Add("@Prioridad", ticket.Prioridad.nombre.ToString());
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
                throw new ExceptionsControl("Ha ocurrido un error al reemplazar las etiquetas", ex);
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
                throw new ExceptionsControl("No se pudo enviar el correo. Verifica el correo electrónico que ingresó", ex);
            }
        }
    }
}