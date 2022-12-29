using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_TicketController
{
    [TestClass]
    public class TestAgregarTipo_TicketCtrl
    {

        private readonly Tipo_TicketController _controller;
        private readonly Mock<ITipo_TicketDAO> _serviceMock;

        public TestAgregarTipo_TicketCtrl()
        {
            _serviceMock = new Mock<ITipo_TicketDAO>();
            _controller = new Tipo_TicketController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para agregar un tipo ticket

        [TestMethod]
        public void CrearTipoTicketCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.RegistroTipo_Ticket(It.IsAny<Tipo_TicketDTOCreate>()));
         
            //act
            var result = _controller.PostTipo_Ticket(It.IsAny<Tipo_TicketDTOCreate>());

            //Assert
         
        }

    }
}


