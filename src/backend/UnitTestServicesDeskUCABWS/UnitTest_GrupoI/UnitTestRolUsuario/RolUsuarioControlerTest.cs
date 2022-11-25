using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestRolUsuario
{
    [TestClass]
    public class RolUsuarioControlerTest
    {
        private readonly AsignacionRolController _controller;
        private readonly Mock<IUserRol> _serviceMock;

        public RolUsuarioControlerTest()
        {
            _serviceMock = new Mock<IUserRol>();
            _controller = new AsignacionRolController(_serviceMock.Object);
        }

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar rol de un usuario")]
        public void ConsultaRolesCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerUsuariosRoles()).Returns(new List<RolUsuarioDTO>());
            var application = new ApplicationResponse<List<RolUsuarioDTO>>();

            //act
            var result = _controller.ConsultarUsuarios();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todos los roles excepcion")]
        public void ConsultaRolesCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerUsuariosRoles()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarUsuarios();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar rol de un usuario en especifico exitoso")]
        public void GetEtiquetaByGuidCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.consularRolID(It.IsAny<Guid>())).Returns(new RolUsuarioDTO());
            var application = new ApplicationResponse<RolUsuarioDTO>();

            //act
            var result = _controller.GetRolByUser(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar un usuario en especificoo excepcion")]
        public void GetEtiquetaByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.consularRolID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetRolByUser(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear plantilla notificacion exitoso")]
        public void CrearPlantillaCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.AgregarRol(It.IsAny<RolUsuario>())).Returns(new RolUsuarioDTO());
            var application = new ApplicationResponse<String>();

            //act
            var result = _controller.CrearRolUsuario(It.IsAny<RolUsuarioDTO>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

    }
}
