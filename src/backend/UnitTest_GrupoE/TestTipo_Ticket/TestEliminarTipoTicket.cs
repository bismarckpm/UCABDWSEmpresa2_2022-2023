using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
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
    public class TestEliminarTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private IMapper mapper;
        public TestEliminarTipoTicket()
        {


            context = new Mock<IDataContext>();

            TipoticketDAO = new Tipo_TicketService(context.Object, mapper);
            context.SetupDbContextData();
        }


     /*  [TestMethod]
        public void EliminarTipoTicketExitoso()
        {

            //arrange

            Tipo_TicketDTO tipo = new Tipo_TicketDTO
            {
                Id = "36B2054E-BC66-4EA7-A5CC-dsd",
                fecha_elim = DateTime.UtcNow
            };
                //act
                var result = TipoticketDAO.EliminarTipoTicket(Tipo);
            //assert

            Assert.AreEqual(result.fecha_elim, "null");

        }*/
       

       /* [TestMethod]
        public void EntrarEnExceptionDelete()
        {
            //arrange
            var expected = new ExceptionsControl("No se pudo eliminar el tipo de ticket", new Exception());
            context.Setup(c => c.Tipos_Tickets.Find(It.IsAny<Guid>)).Throws(new Exception());
            var result = new ExceptionsControl();

            //act
            try
            {
              TipoticketDAO.EliminarTipoTicket("");
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }*/
    }
}
