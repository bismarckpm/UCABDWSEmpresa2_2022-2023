using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
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
        public TestConsultarTipoTicket()
        {

            
            context = new Mock<IDataContext>();
            
            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);
            TipoticketDAO = new Tipo_TicketService(context.Object, mapper);
            context.SetupDbContextData();
        }
     //Test camino feliz para hacer el consultar tipo ticket

        [TestMethod]
        public void CaminoFelizConsultarTest()
        {

            //arrange
            
            //act
            var result = TipoticketDAO.ConsultarTipoTicket();
            //assert

            Assert.AreEqual(result.Count(), context.Object.Tipos_Tickets.ToList().Count());
        }

     //Test para la excepcion de consultar tipo ticket      
        [TestMethod]
        public void EntrarEnExceptionTest()
        {

            context.Setup(a => a.Tipos_Tickets).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.ConsultarTipoTicket());
            
        }
    //Test para la excepcion ExceptionsControl de eliminar tipo ticket      
        [TestMethod]
        public void EntrarEnExceptionControlTest()
        {
            //arrage
            context.Setup(a => a.Tipos_Tickets).Throws(new ExceptionsControl(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.ConsultarTipoTicket());
           
        }
    }
}
