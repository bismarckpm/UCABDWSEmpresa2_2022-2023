using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_Ticket
{

    [TestClass]
    public class TestConsultarEstadoDepartamentoTicket
    {
        Mock<IDataContext> context;
        private readonly EstadoService EstadoDAO;
        private IMapper mapper;

        public TestConsultarEstadoDepartamentoTicket()
        {
            context = new Mock<IDataContext>();

            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);

            EstadoDAO = new EstadoService(context.Object, mapper);
            context.SetupDbContextData();
        }

        //Test para la excepcion Exception para deshabilitar estado  
        [TestMethod]
        public void ConsultarEstadoDepartamentoTest()
        {

            var Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C");

            var result = EstadoDAO.ConsultarEstadosDepartamentoTicket(Id);

            Assert.IsTrue(result.Count() > 0);

        }
    }
}

