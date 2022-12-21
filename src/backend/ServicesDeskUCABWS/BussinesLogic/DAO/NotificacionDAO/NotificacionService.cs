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

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public class NotificacionService : INotificacion
    {
        const string correo = "DesarrolloSoftwareUCAB2@hotmail.com";
        const string clave = "Desarrollo_SoftwareUCAB_2";
        const string alias = "ServiceDeskUCAB";
        const string host = "smtp.office365.com";
        const int puerto = 587;
        Dictionary<string, string> etiquetasEstatico = new Dictionary<string, string>();

        //Servicio para reeemplazar las etiquetas de la plantilla notificación
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla)
        {
			try
            {
				var descripcionPlantilla = Plantilla.Descripcion;
				AgregarEtiquetasDiccionario(ticket);

                foreach (EtiquetaDTO etiqueta in Plantilla.TipoEstado.etiqueta)
                {
					descripcionPlantilla = Regex.Replace(descripcionPlantilla, etiqueta.Nombre, etiquetasEstatico.GetValueOrDefault(etiqueta.Nombre));
                }

                return descripcionPlantilla;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Ha ocurrido un error al reemplazar las etiquetas", ex);
            }
        }

        private void AgregarEtiquetasDiccionario(Ticket ticket)
        {
			etiquetasEstatico.Add("@Cargo", $"{ticket.Emisor.Cargo.nombre_departamental}");
			etiquetasEstatico.Add("@Usuario", $"{ticket.Emisor.primer_nombre} {ticket.Emisor.primer_apellido}");
			etiquetasEstatico.Add("@Ticket", $"{ticket.titulo}");
			etiquetasEstatico.Add("@Prioridad", $"{ticket.Prioridad.nombre}");
			etiquetasEstatico.Add("@TipoTicket", $"{ticket.Tipo_Ticket.nombre}");

			ValidacionTicketEstado(ticket);
            ValidacionTicketDepartamentoGrupo(ticket);
		}

		private void ValidacionTicketEstado(Ticket ticket)
        {
			if (ticket.Estado != null) 
				etiquetasEstatico.Add("@Estado", $"{ticket.Estado.Estado_Padre.nombre}");
		}

		private void ValidacionTicketDepartamentoGrupo(Ticket ticket)
		{
			if (ticket.Departamento_Destino != null) 
			{
				etiquetasEstatico.Add("@Departamento", $"{ticket.Departamento_Destino.nombre}");
				etiquetasEstatico.Add("@Grupo", $"{ticket.Departamento_Destino.grupo.nombre}");
			}
		}

		//Metodo para hacer el envio del correo
		public Boolean EnviarCorreo(PlantillaNotificacionDTO plantilla, string correoDestino)
		{
			try
			{
				var credenciales = new NetworkCredential(correo, clave);
				var mail = new MailMessage()
				{
					From = new MailAddress(correo, alias),
					Subject = plantilla.Titulo,
					Body = plantilla.Descripcion,
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