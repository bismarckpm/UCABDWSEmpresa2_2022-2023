using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{
    [TestClass]
    public class TestVerificarAprobacionTicketJerarquico
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<ITicketDAO> ticketDAO;
        private readonly IMapper mapper;
        private readonly Mock<INotificacion> notificacion;

        public TestVerificarAprobacionTicketJerarquico()
        {
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaMapper(),
                new EtiquetaTipoEstadoMapper(),
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            mapper = new Mapper(configuration);
            ticketDAO = new Mock<ITicketDAO>();
            context = new Mock<IDataContext>();
            notificacion = new Mock<INotificacion>();
            VotoDAO = new Votos_TicketService(context.Object, ticketDAO.Object,mapper, notificacion.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void RechazadoJerarquico()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Muy Mal",
                voto = "Rechazado"

            };
            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);
            var listavotos = context.Object.Votos_Tickets.Where(c => c.IdTicket.ToString().ToUpper() == Voto.IdTicket.ToUpper());
            Assert.IsTrue(listavotos.TakeWhile(c=>c.voto=="Rechazado").Count()==listavotos.Count());

        }

        [TestMethod]
        public void AprobadoJerarquicoSiguienteRonda()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Perfecto",
                voto = "Aprobado"

            };
            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);
            var listavotos = context.Object.Votos_Tickets.Where(c => c.IdTicket.ToString().ToUpper() == Voto.IdTicket.ToUpper()
                                                            && c.voto == "Aprobado");
            Assert.IsTrue(listavotos.TakeWhile(c => c.voto == "Aprobado").Count() == 3);

        }

        [TestMethod]
        public void AprobadoJerarquicoRondaFinal()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "0F636FB4-7F04-4A2E-B2C2-359B99BE85D1",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Perfecto",
                voto = "Aprobado"
                
            };

            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);
            var listavotos = context.Object.Votos_Tickets.Where(c => c.IdTicket.ToString().ToUpper() == Voto.IdTicket.ToUpper());
            Assert.IsTrue(listavotos.TakeWhile(c => c.voto == "Aprobado").Count() == listavotos.Count());
            var ticket = context.Object.Tickets.Find(Guid.Parse(Voto.IdTicket));
            Assert.AreEqual(ticket.Estado.nombre, "Siendo Procesado");
        }

        [TestMethod]
        public void TicketPendiente()
        {
            //arrange

            var entrada =context.Object.Tickets.Find(new Guid("5992E4A2-4737-42FB-88E2-FBC37EF26751"));
            var tipo_Ticket = context.Object.Tipos_Tickets.Find(Guid.Parse("39C1E9A1-9DDE-4F1A-8FBB-4D52D4E45A19"));

            //act
            var result = tipo_Ticket.VerificarVotacion(entrada,context.Object,notificacion.Object);

            //assert
            Assert.AreEqual(result, "Pendiente");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionsControl))]
        public void EntraEnLaExcepccionDevuelveFallido()
        {
            //arrange

            var entrada = context.Object.Tickets.Find(new Guid("5992E4A2-4737-42FB-88E2-FBC37EF26751"));

            var tipo_Ticket = context.Object.Tipos_Tickets.Find(Guid.Parse("39C1E9A1-9DDE-4F1A-8FBB-4D52D4E45A19"));

            entrada.Votos_Ticket = null;
            //context.Setup(c => c.Tickets).Throws(new Exception());
            //act
            var result = tipo_Ticket.VerificarVotacion(entrada, context.Object,notificacion.Object);

        }

    }
}
