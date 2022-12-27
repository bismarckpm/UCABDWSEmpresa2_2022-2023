using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{
    [TestClass]
    public class TestAgregarVoto
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private readonly ITicketDAO ticketDAO;

        public TestAgregarVoto()
        {
            context = new Mock<IDataContext>();
            TipoticketDAO = new Tipo_TicketService(context.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizAgregarVoto()
        {
            /*//arrange
            var entrada = new List<Votos_Ticket>() {
                new Votos_Ticket()
                {
                    IdTicket = Guid.Parse("EC1DDF25-80AF-47AF-AA24-A5B159C5A90F"),
                    Empleado = (Empleado) ListaUsuario[2],
                    IdTicket = ListaTickets[0].Id,
                    IdUsuario = ListaUsuario[2].Id,
                    voto = "Pendiente"
                },
                new Votos_Ticket()
                {

                }
            };
            //act

            var result = 
            //assert*/

        }
    }
}
