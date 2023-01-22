using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public class NotificacionService : INotificacion
    {
        const string correo = "UCAB2ENTREGADS@outlook.com";
        const string clave = "UCAB2_ENTREGADS";
        const string alias = "ServiceDeskUCAB";
        const string host = "smtp.office365.com";
        const int puerto = 587;
		Dictionary<string, string> etiquetasEstatico = new Dictionary<string, string>();

		//Servicio para reeemplazar las etiquetas de la plantilla notificación
		public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla)
        {
			try
            {
				AgregarEtiquetasDiccionario(ticket);

                foreach (EtiquetaDTO etiqueta in Plantilla.TipoEstado.etiqueta)
                {
					Plantilla.Descripcion = Regex.Replace(Plantilla.Descripcion, etiqueta.Nombre, etiquetasEstatico.GetValueOrDefault(etiqueta.Nombre));
                }

                return Plantilla.Descripcion;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Ha ocurrido un error al reemplazar las etiquetas", ex);
            }
        }

		//Metodo para agregar las etiquetas al diccionario
        private void AgregarEtiquetasDiccionario(Ticket ticket)
        {
			if(ticket.Emisor.Cargo != null)
				etiquetasEstatico.Add("@Cargo", $"{ticket.Emisor.Cargo.nombre_departamental}");

			if(ticket.Emisor != null)
				etiquetasEstatico.Add("@Usuario", $"{ticket.Emisor.primer_nombre} {ticket.Emisor.primer_apellido}");

			if(ticket != null)
				etiquetasEstatico.Add("@Ticket", $"{ticket.titulo}");

			if(ticket.Prioridad != null)
				etiquetasEstatico.Add("@Prioridad", $"{ticket.Prioridad.nombre}");

			if(ticket.Tipo_Ticket != null)
				etiquetasEstatico.Add("@TipoTicket", $"{ticket.Tipo_Ticket.nombre}");

			if (ticket.Estado != null)
				etiquetasEstatico.Add("@Estado", $"{ticket.Estado.Estado_Padre.nombre}");

			if (ticket.Departamento_Destino != null)
				etiquetasEstatico.Add("@Departamento", $"{ticket.Departamento_Destino.nombre}");

			if (ticket.Departamento_Destino.grupo != null)
				etiquetasEstatico.Add("@Grupo", $"{ticket.Departamento_Destino.grupo.nombre}");
			else
                etiquetasEstatico.Add("@Grupo", "");
        }

		//Metodo para hacer el envio del correo
		public Task EnviarCorreo(PlantillaNotificacionDTO plantilla, string correoDestino)
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
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				throw new ExceptionsControl("No se pudo enviar el correo. Verifica el correo electrónico que ingresó", ex);
			}
		}


        //Samuel agrego esto
        private readonly IDataContext _dataContext;
        private readonly IPlantillaNotificacion _plantillaNotificacion;

        public NotificacionService(IDataContext dataContext, IPlantillaNotificacion plantillaNotificacion)
        {
            _dataContext= dataContext;
            _plantillaNotificacion = plantillaNotificacion;
        }
        public NotificacionService()
        {
        }
        public async Task<bool> EnviarNotificacion(Ticket ticket, TipoNotificacion Estado, List<Empleado> ListaEmpleados, IDataContext contexto)
        {
            var plant = _plantillaNotificacion.ConsultarPlantillaTipoEstadoID(ticket.Estado.Estado_Padre.Id);
            plant.Descripcion = ReemplazoEtiqueta(ticket,plant);
            var notificacion=Notificacion.GetInstance(Estado);
            var EmpleadosCorreo = notificacion.ObtenerUsuariosAEnviarCorreo(ticket, ListaEmpleados, contexto);
            foreach (var emp in EmpleadosCorreo){
                try{
                    await EnviarCorreo(plant, emp.correo);
                }catch (ExceptionsControl) { }
            }
            return true;
        }
    }
}