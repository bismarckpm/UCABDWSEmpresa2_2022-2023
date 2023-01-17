using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.EstadosController;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEstadoController
{
   

    [TestClass]
    public class TestModificarEstadoCtrl
    {

        private readonly EstadoController _controller;
        private readonly Mock<IEstadoDAO> _serviceMock;


        public TestModificarEstadoCtrl()
        {
            _serviceMock = new Mock<IEstadoDAO>();
           
            _controller = new EstadoController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para modificar un estado

        [TestMethod]
        public void ModificarEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ModificarEstado(It.IsAny<EstadoDTOUpdate>())).Returns(new EstadoDTOUpdate());
            var application = new ApplicationResponse<EstadoDTOUpdate> ();

            //act
            var result = _controller.EsitarEstadoCtrl(It.IsAny<EstadoDTOUpdate>()); 

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para eliminar un tipo ticket

        [TestMethod]
        public void ModificarEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ModificarEstado(It.IsAny<EstadoDTOUpdate>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EsitarEstadoCtrl(It.IsAny<EstadoDTOUpdate>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}




