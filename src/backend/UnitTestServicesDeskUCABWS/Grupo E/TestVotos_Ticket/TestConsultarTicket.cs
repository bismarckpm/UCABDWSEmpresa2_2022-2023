using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class TestConsultarTicket
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<ITicketDAO> ticketDAO;

        public TestConsultarTicket()
        {
            context = new Mock<IDataContext>();
            ticketDAO = new Mock<ITicketDAO>();
            VotoDAO = new Votos_TicketService(context.Object,ticketDAO.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizConsultarVotos()
        {
            var entrada = Guid.Parse("C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A");

            var result = VotoDAO.ConsultaVotos(entrada);

            Assert.AreEqual(result.Data.ToList().Count(), 3);
        }

    }
}
