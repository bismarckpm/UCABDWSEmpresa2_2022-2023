using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CTicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Data;
using UnitTest_GrupoE.DataSeed;

namespace UnitTest_GrupoE
{
    [TestClass]
    public class UnitTest_TipoTicketDAO
    {
        //Mock<IDataContext> contexto = new Mock<IDataContext>() ;
        //Mock<Departamento> departamento = new Mock<Departamento>() ;
        //Mock<TicketDAO> ticket = new Mock<TicketDAO>();
        //private readonly Mock<IDataContext> _contextMock;
        private readonly TicketDAO ticketDAO;
        private readonly DataContext context;

        
        public UnitTest_TipoTicketDAO()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "BDDesarrollo")
                .Options;
            //var dataseed = new DataSeedMemoryDataBase(); 
            
            this.context = new DataContext(options);
            this.context.Database.EnsureCreated();

            context = DataSeedMemoryDataBase.SetupDbContextData(context);
            
            //_contextMock = new Mock<IDataContext>();
            //_contextMock.SetupDbContextData();
            ticketDAO = new TicketDAO(context);
        }

        

        [TestMethod]
        public void RegistroTicketExitoso()
        {

            //arrange
            TicketCreateDTO ticketDTO = new TicketCreateDTO()
            {
                titulo = "necesito una engrapadora",
                descripcion = "Una engrapadora de grapa lisa",
                Prioridad = "2DF5B096-DC5A-421F-B109-2A1D1E650807",
                Departamento_Destino = "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                Tipo_Ticket = "F863DBA2-5093-4E89-917A-03B5F585B3E7",
                Emisor = "E40D0211-EA65-49BB-BAEE-E8A5F504F3B1"
            };
            //act
            var result = ticketDAO.RegistroTicket(ticketDTO);

            //assert

            Assert.AreEqual(result.Data, ticketDTO);


            /*TicketCreateDTO ticketDTO = new TicketCreateDTO()
            {
                titulo = "necesito una engrapadora",
                descripcion = "Una engrapadora de grapa lisa",
                Prioridad = "2DF5B096-DC5A-421F-B109-2A1D1E650807",
                Departamento_Destino = "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                Tipo_Ticket = "F863DBA2-5093-4E89-917A-03B5F585B3E7",
                Emisor = "E40D0211-EA65-49BB-BAEE-E8A5F504F3B1"
            };

            Ticket expected = new Ticket()
            {
                titulo = "necesito una engrapadora",
                descripcion = "Una engrapadora de grapa lisa",
            };
            context.Setup(a => a.Prioridades.Find(Guid.Parse(ticketDTO.Prioridad))).Returns(new Prioridad()
            {
                Id = Guid.Parse(ticketDTO.Prioridad),
                nombre = "Alta",
                descripcion = "Algo"
                
            });*/

            //act
            //Ticket actual= ticket.Object.RegistroTicket(ticketDTO);
            //assert

            //Assert.AreEqual(expected, actual);


        }
        [TestCleanup()]
        public void LimpiarBD()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }

    
}