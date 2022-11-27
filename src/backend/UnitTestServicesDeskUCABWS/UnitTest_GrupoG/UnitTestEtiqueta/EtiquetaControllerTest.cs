using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestEtiqueta
{
    [TestClass]
    public class EtiquetaControllerTest
    {

        private readonly EtiquetaController _controller;
        private readonly Mock<IEtiqueta> _serviceMock;

        public EtiquetaControllerTest()
        {
            _serviceMock = new Mock<IEtiqueta>();
            _controller = new EtiquetaController(_serviceMock.Object);
        }


//*
//PRUEBAS UNITARIAS para consultar todas las etiquetas (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas las etiquetas exitoso")]
        public void ConsultaEtiquetasCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaEtiquetas()).Returns(new List<EtiquetaDTO>());
            var application = new ApplicationResponse<List<EtiquetaDTO>>();

            //act
            var result = _controller.ConsultaEtiquetasCtrl();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas las etiquetas excepcion")]
        public void ConsultaEtiquetasCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaEtiquetas()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultaEtiquetasCtrl();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar una etiqueta en especifico (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una etiqueta en especifico exitoso")]
        public void GetEtiquetaByGuidCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEtiquetaGUID(It.IsAny<Guid>())).Returns(new EtiquetaDTO());
            var application = new ApplicationResponse<EtiquetaDTO>();

            //act
            var result = _controller.GetEtiquetaByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una etiqueta en especificoo excepcion")]
        public void GetEtiquetaByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEtiquetaGUID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetEtiquetaByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}
