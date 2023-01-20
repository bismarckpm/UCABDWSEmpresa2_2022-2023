using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
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
    public class TestVerificarAprobacionTicketParalelo
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<ITicketDAO> ticketDAO;
        private readonly Mock<INotificacion> notificacion;
        private readonly IMapper mapper;

        public TestVerificarAprobacionTicketParalelo()
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
        public void AprobadoParalelo()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobado"

            };
            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);

            //Assert.AreEqual(context.Object.Votos_Tickets.Where(x => x.IdTicket == Guid.Parse(Voto.IdTicket)).Count()
              //  , result.Votos_Tickets.Where(x => x.voto == "Aprobado").Count());

        }

        [TestMethod]
        public void RechazadoParalelo()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Rechazado"

            };
            //act
            var result = VotoDAO.Votar(Voto);

            //assert
            Assert.IsTrue(result.Success == true);
            Assert.AreEqual(result.Data.comentario, Voto.comentario);
            Assert.AreEqual(result.Data.voto, Voto.voto);
            Assert.AreEqual(context.Object.Votos_Tickets.Where(x => x.IdTicket == Guid.Parse(Voto.IdTicket)).Count()
                ,context.Object.Votos_Tickets.Where(x => x.IdTicket == Guid.Parse(Voto.IdTicket) && x.voto == "Rechazado").Count());

        }

        /*[TestMethod]
        public void TicketPendiente()
        {
            //arrange

            var entrada = new Guid("132A191C-95AE-4538-8E78-C5EDD3092552");
            var tipo_Ticket = context.Object.Tipos_Tickets.Find(Guid.Parse("F863DBA2-5093-4E89-917A-03B5F585B3E7"));
            //act
            var result = tipo_Ticket.VerificarVotacion(entrada, context.Object);

            //assert
            Assert.AreEqual(result, "Pendiente");
        }*/

        /*[TestMethod]
        [ExpectedException(typeof(ExceptionsControl))]
        public void EntraEnLaExcepccionDevuelveFallido()
        {
            //arrange

            var entrada = new Guid("132A191C-95AE-4538-8E78-C5EDD3092552");
            var tipo_Ticket = context.Object.Tipos_Tickets.Find(Guid.Parse("F863DBA2-5093-4E89-917A-03B5F585B3E7"));

            context.Setup(c => c.Tickets).Throws(new Exception());

            //act
            var result = tipo_Ticket.VerificarVotacion(entrada, context.Object);

            
        }*/

    }
}
