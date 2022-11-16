using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class TestVerificarAprobacionTicketJerarquico
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;

        public TestVerificarAprobacionTicketJerarquico()
        {
            context = new Mock<IDataContext>();
            VotoDAO = new Votos_TicketService(context.Object);
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
            Assert.AreEqual(ticket.Estado.nombre, "Aprobado D1");
        }



        [TestMethod]
        public void TicketPendiente()
        {
            //arrange

            var entrada = new Guid("5992E4A2-4737-42FB-88E2-FBC37EF26751");

            //act
            var result = VotoDAO.VerificarAprobacionTicketJerarquico(entrada);

            //assert
            Assert.AreEqual(result, "Pendiente");
        }

        [TestMethod]
        public void EntraEnLaExcepccionDevuelveFallido()
        {
            //arrange

            var entrada = new Guid("5992E4A2-4737-42FB-88E2-FBC37EF26751");
            context.Setup(c => c.Tickets).Throws(new Exception());

            //act
            var result = VotoDAO.VerificarAprobacionTicketJerarquico(entrada);

            //assert
            Assert.AreEqual(result, "Fallido");
        }

    }
}
