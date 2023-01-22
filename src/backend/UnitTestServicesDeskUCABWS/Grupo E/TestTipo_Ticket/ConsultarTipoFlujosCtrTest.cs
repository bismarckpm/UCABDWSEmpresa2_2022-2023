using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_Ticket
{
    [TestClass]
    public class ConsultarTipoFlujosCtrTest
    {
        Mock<ITipo_TicketDAO> tipo_ticketDAO;
        private readonly Tipo_TicketController tipo_TicketController;
        private IMapper mapper;
        public ConsultarTipoFlujosCtrTest()
        {
            tipo_ticketDAO = new Mock<ITipo_TicketDAO>();

            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);
            tipo_TicketController = new Tipo_TicketController(tipo_ticketDAO.Object);
        }

        [TestMethod]
        public void CaminoFelizConsultarTest()
        {
            //arrange
            tipo_ticketDAO.Setup(x => x.ConsultarTipoFlujos()).Returns(new List<Modelo_Aprobacion>());
            //act
            var result = tipo_TicketController.ObtenerTipoFlujos();
            //assert
            Assert.AreEqual(result.Data.GetType(), typeof(List<Modelo_Aprobacion>));
        }

        [TestMethod]
        public void ExceptionConsultarTest()
        {
            //arrange
            tipo_ticketDAO.Setup(x => x.ConsultarTipoFlujos()).Throws(new ExceptionsControl());
            //act
            var result = tipo_TicketController.ObtenerTipoFlujos();
            //assert
            Assert.AreEqual(result.Success,false);
        }
    }
}
