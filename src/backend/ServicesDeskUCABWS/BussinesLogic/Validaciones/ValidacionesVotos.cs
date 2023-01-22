using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Data;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones
{
    public class ValidacionesVotos
    {
        public static void LongitudComentario(Votos_Ticket voto)
        {
            if (voto.comentario.Length > 300)
            {
                throw new ExceptionsControl(ErroresVotos.COMENTARIO_FUERA_RANGO);
            }
        }

        public static void VerificarEstadoVoto(Votos_Ticket voto)
        {
            var VotosPermitidos = new string[] { "Aprobado", "Rechazado", "Pendiente" };
            if (!VotosPermitidos.Contains(voto.voto))
            {
                throw new ExceptionsControl(ErroresVotos.VOTO_NO_VALIDO);
            }
        }

        public static void VerificarTicket(Votos_Ticket voto, IDataContext dataContext)
        {
            if (dataContext.Tickets.Find(voto.IdTicket) == null)
            {
                throw new ExceptionsControl(ErroresVotos.ERROR_TICKET_DESC);
            }
        }

        public static void VerificarUsuario(Votos_Ticket voto, IDataContext dataContext)
        {
            if (dataContext.Usuarios.Find(voto.IdUsuario) == null)
            {
                throw new ExceptionsControl(ErroresVotos.ERROR_USUARIO_DESC);
            }
        }

        public static void VerificarVoto(Votos_Ticket voto, IDataContext dataContext)
        {
            if (dataContext.Votos_Tickets.Where(x => x.IdTicket == voto.IdTicket &&
                    x.IdUsuario == voto.IdUsuario).FirstOrDefault() == null)
            {
                throw new ExceptionsControl(ErroresVotos.VOTO_NO_PERMITIDO);
            }
        }
        public static void VerificarTurno(Votos_Ticket voto, IDataContext dataContext)
        {
            if (BuscarTicket(voto.IdTicket, dataContext).Tipo_Ticket.ObtenerTipoAprobacion() == "Modelo_Jerarquico")
            {
                if (BuscarTicket(voto.IdTicket, dataContext).nro_cargo_actual != BuscarVoto(voto.IdTicket, voto.IdUsuario, dataContext).Turno)
                {
                    throw new ExceptionsControl(ErroresVotos.VOTACION_EXPIRADA);
                }
            }
        }

        public static Ticket BuscarTicket(Guid Id, IDataContext dataContext)
        {
            return dataContext.Tickets.Include(x=>x.Tipo_Ticket).Where(x => x.Id == Id).FirstOrDefault();
        }

        public static Votos_Ticket BuscarVoto(Guid IdTicket, Guid IdUsuario, IDataContext dataContext)
        {
            return dataContext.Votos_Tickets.Where(x => x.IdTicket == IdTicket && x.IdUsuario ==IdUsuario).FirstOrDefault();
        }

    }
}
