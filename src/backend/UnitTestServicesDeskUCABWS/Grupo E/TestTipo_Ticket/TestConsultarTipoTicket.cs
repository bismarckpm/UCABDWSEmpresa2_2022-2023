using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo;
using ServicesDeskUCABWS.BussinesLogic.Response;
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

        //Test para consultar tipo ticket por Id     
        [TestMethod]
        public void ConsultarTipoTicketIDServiceTest()
        {
            //arrange
            var id = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E");

            //act
            var result = TipoticketDAO.ConsultarTipoTicketGUID(id);

            //assert
            Assert.AreEqual(id, result.Id);
        }

        //Test para la excepcion ExceptionsControl para consultar tipo ticket por Id      
        [TestMethod]
        public void EntrarEnExceptionControlIdTest()
        {
            var id = Guid.Parse("36B2054E-BC77-4EA7-A5CC-7BA9137BC20E");
            //arrage
            context.Setup(a => a.Tipos_Tickets).Throws(new ExceptionsControl(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.ConsultarTipoTicketGUID(id));

        }

        //Test para consultar tipo ticket por el nombtre
        [TestMethod]
        public void ConsultarTipoTicketNombreServiceTest()
        {
            //arrange
            var nombre = "Solicitud";

            //act
            var result = TipoticketDAO.ConsultarTipoTicketNomb(nombre);

            //assert
            Assert.AreEqual(nombre, result.nombre);
        }


        //Test para la excepcion ExceptionsControl para consultar tipo ticket por el nombre     
        [TestMethod]
        public void EntrarEnExceptionControlNombreTest()
        {
            var nombre = "Solicitud";
            //arrage
            context.Setup(a => a.Tipos_Tickets).Throws(new ExceptionsControl(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.ConsultarTipoTicketNomb(nombre));

        }

        //Test para la excepcion ExceptionsControl para consultar tipo ticket agregar ticket     
        [TestMethod]
        public void ConsultarTipoTicketAgregarTicketTest()
        {
            var id = new Guid("36B2054E-BC77-4EA7-A5CC-7BA9137BC20E");
            //arrage
            var result = TipoticketDAO.ConsultaTipoTicketAgregarTicket(id);

            //assert
            Assert.IsTrue(result.Count() > 0);
        }


        //Test para la excepcion ExceptionsControl para consultar tipo ticket agregar ticket    
        //[TestMethod]
        /*public void EntrarEnExceptionControlConsultarTest()
        {
          
            //arrage
            context.Setup(a => a.Tipos_Tickets).Throws(new FormatException(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.ConsultaTipoTicketAgregarTicket(It.IsAny<Guid>()));

        }*/

    }
}
