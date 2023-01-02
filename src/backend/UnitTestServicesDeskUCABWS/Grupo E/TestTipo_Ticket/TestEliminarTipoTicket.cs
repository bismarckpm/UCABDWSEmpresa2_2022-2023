using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
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
    public class TestEliminarTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private IMapper mapper;

        public TestEliminarTipoTicket()
        {


            context = new Mock<IDataContext>();

            TipoticketDAO = new Tipo_TicketService(context.Object,mapper);
            context.SetupDbContextData();
        }

        //Test camino feliz para hacer el eliminar tipo ticket
        [TestMethod]
        public void EliminarTipoTicketExitoso()
        {
            //arrage

            var data = new TipoTicket_FlujoNoAprobacion
            {
                Id = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E"),

            };
            context.Setup(a => a.DbContext.SaveChanges());

            //act 
            var result = TipoticketDAO.EliminarTipoTicket(data.Id);

            //assert
            Assert.IsTrue(result);

        }

        //Test para la excepcion de eliminar tipo ticket      
        [TestMethod]
        public void EntrarEnExceptionDelete()
        {
            //arrange

            //act
            context.Setup(a => a.Tipos_Tickets).Throws(new Exception(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(()=> TipoticketDAO.EliminarTipoTicket(Guid.Empty));
           
        }

        //Test para validar camino feliz el eliminar tipo ticket  
        [TestMethod]
        public void CaminoFelizValidacionEliminar()
        {
            //arrange
            var entrada = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E");

            //act 
            TipoticketDAO.ValidarDatosEntradaTipo_Ticket_Delete(entrada);

            //assert

        }

        //Test para validar el ID del eliminar tipo ticket 
        [TestMethod]
        public void ErrorEnID()
        {
           /* context.Setup(a => a.Tipos_Tickets).Throws(new ExceptionsControl(""));
            Assert.ThrowsException<ExceptionsControl>(() => TipoticketDAO.EliminarTipoTicket(Guid.Empty));*/

           // arrange
            var entrada = Guid.Parse("36B2054E-BC81-4EA7-A5CC-7BA9137BC20E");

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.FORMATO_ID_TICKET);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket_Delete(entrada);

            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            //Assert
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);
        }



    }
}


