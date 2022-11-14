using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestTipo_Ticket
{
    [TestClass]
    public class TestConsultarTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private IMapper mapper;
        public TestConsultarTipoTicket(IMapper mapper)
        {
            context = new Mock<IDataContext>();
            TipoticketDAO = new Tipo_TicketService(context.Object);
            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            context.SetupDbContextData();
            this.mapper = mapper;
        }

        [TestMethod]
        public void CaminoFelizConsultar()
        {

            //arrange
            
            //act
            var result = TipoticketDAO.ConsultarTipoTicket();
            //assert

            Assert.AreEqual(result.Count(), context.Object.Tipos_Tickets.ToList().Count());
        }
    }
}
