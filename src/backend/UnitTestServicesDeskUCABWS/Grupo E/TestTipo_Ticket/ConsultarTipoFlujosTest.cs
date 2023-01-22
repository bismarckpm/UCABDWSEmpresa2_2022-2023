using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
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
    public class ConsultarTipoFlujosTest
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private readonly Tipo_TicketController tipo_TicketController;
        private IMapper mapper;
        public ConsultarTipoFlujosTest()
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

        [TestMethod]
        public void CaminoFelizConsultarTest()
        {
            //act
            var result = TipoticketDAO.ConsultarTipoFlujos();
            //assert
            Assert.AreEqual(result.Count(), context.Object.Modelos_Aprobacion.ToList().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionsControl))]
        public void ExceptionConsultarTest()
        {
            //arrange
            context.Setup(x=>x.Modelos_Aprobacion).Throws(new Exception());
            //act
            var result = TipoticketDAO.ConsultarTipoFlujos();
        }
    }
}
