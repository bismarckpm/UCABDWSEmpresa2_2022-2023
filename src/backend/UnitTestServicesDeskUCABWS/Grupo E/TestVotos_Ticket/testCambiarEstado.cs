using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class testCambiarEstado
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly ITicketDAO ticketDAO;

        public testCambiarEstado()
        {
            context = new Mock<IDataContext>();
            VotoDAO = new Votos_TicketService(context.Object, ticketDAO);
            context.SetupDbContextData();
        }
        /*[TestMethod]
        public void CaminoFelizCambiarEstado()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));
            //act
            var result= VotoDAO.CambiarEstado(entrada,"Aprobado");
            //assert
            Assert.AreEqual(result,true);
        }

        [TestMethod]
        public void ExceptionCambiarEstado()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));
            context.Setup(c => c.Tickets.Update(It.IsAny<Ticket>())).Throws(new Exception());
            //act
            var result = VotoDAO.CambiarEstado(entrada, "Aprobado");
            //assert
            Assert.AreEqual(false, result);
        }*/
    }
}
