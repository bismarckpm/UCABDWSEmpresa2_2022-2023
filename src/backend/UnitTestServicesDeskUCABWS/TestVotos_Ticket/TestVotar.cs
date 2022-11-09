using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CVotos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_GrupoE.DataSeed;

namespace UnitTest_GrupoE.TestVotos_Ticket
{

    [TestClass]
    public class TestVotar
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketDAO VotoDAO;

        public TestVotar()
        {
            context = new Mock<IDataContext>();
            VotoDAO = new Votos_TicketDAO(context.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizVotar()
        {
            //arrange
            var Voto = new Votos_TicketDTOCreate()
            {
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobado"
                
            };
            //act
            var result = VotoDAO.Votar(Voto);
            //assert

            Assert.IsTrue(result.Success == true);
            
        }
    }
}