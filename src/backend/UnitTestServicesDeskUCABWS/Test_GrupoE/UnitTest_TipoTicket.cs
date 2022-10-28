using Moq;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Persistence.Req1.DAOs;

namespace UnitTest_GrupoE
{
    [TestClass]
    public class UnitTest_TipoTicket
    {
        Mock<IDataContext> DataContext = new Mock<IDataContext>();
        Mock<Tipo_Ticket> tipo_Ticket = new Mock<Tipo_Ticket>();  
        Tipo_TicketDAO tipo_TicketDAO;


        public UnitTest_TipoTicket()
        {
            tipo_TicketDAO = new Tipo_TicketDAO(DataContext.Object);

            DataContext.Setup(d => d.Tipos_Tickets.Update(tipo_Ticket.Object));
            DataContext.Setup(d => d.Tipos_Tickets.Remove(tipo_Ticket.Object));
        }

        [TestMethod]
        public async Task Update_TipoTicketAsync()
        {
            var tipo_ticket = await tipo_TicketDAO.Edit(tipo_Ticket.Object);
            Assert.Equals(tipo_Ticket.Object, tipo_ticket);
        }
        public async Task Delete_TipoTicketAsync() 
        {
            //Aqui deberia crear un tipo ticket
            await tipo_TicketDAO.Delete(tipo_Ticket.Object.Id);
            //Aqui consulto el id del tipo ticket eliminado
            //Luego un assert del id no existente
        }

    }
}