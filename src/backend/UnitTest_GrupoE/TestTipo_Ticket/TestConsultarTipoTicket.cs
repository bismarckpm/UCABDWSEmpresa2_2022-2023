using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
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

        [TestMethod]
        public void CaminoFelizConsultar()
        {

            //arrange
            
            //act
            var result = TipoticketDAO.ConsultarTipoTicket();
            //assert

            Assert.AreEqual(result.Count(), context.Object.Tipos_Tickets.ToList().Count());
        }

        [TestMethod]
        public void EntrarEnException()
        {
            //arrange
            var expected = new ExceptionsControl("Hubo un problema al consultar la lista de Tipos de Tickets", new Exception());
            context.Setup(c => c.Tipos_Tickets).Throws(new Exception());
            var result =new ExceptionsControl();

            //act
            try { 
                TipoticketDAO.ConsultarTipoTicket();
            }
            catch (ExceptionsControl ex) {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

       [TestMethod]
        public void EntrarEnExceptionSQL()
        {
            //arrange
            var expected = new ExceptionsControl("No existen Tipos de tickets registrados", new ExceptionsControl());
            context.Setup(c => c.Tipos_Tickets).Throws(new ExceptionsControl());
            var result = new ExceptionsControl();

            //act
            try
            {
                TipoticketDAO.ConsultarTipoTicket();
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }
    }
}
