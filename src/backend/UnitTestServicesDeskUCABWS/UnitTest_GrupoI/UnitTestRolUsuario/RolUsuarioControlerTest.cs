using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
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
        public void GetUsuarioByGuidCtrlTest()
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
        public void GetRolByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.consularRolID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetRolByUser(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un rol a un usuario exitoso")]
        public void CrearUsuarioRolCtrlTest()
        {
            var UsuarioClient = new RolUsuarioDTO
            {
                idusuario = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                idrol = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
            };
                //arrange
                _serviceMock.Setup(p => p.AgregarRol(It.IsAny<RolUsuario>())).Returns(new RolUsuarioDTO());
            var application = new ApplicationResponse<RolUsuarioDTO>();

            //act
            var result = _controller.CrearRolUsuario(UsuarioClient);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un rol a un usuario excepcion")]
        public void CrearUsuarioRolCtrlExceptionTest()
        {
            var UsuarioClient = new RolUsuarioDTO
            {
                idusuario = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                idrol = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarRol(It.IsAny<RolUsuario>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearRolUsuario(UsuarioClient);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar rol de usuario exitoso")]
        public void EliminarRolUsuario()
        {
            var UsuarioClient = new RolUsuarioDTO
            {
                idusuario = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                idrol = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
            };


            //arrange
            _serviceMock.Setup(p => p.EliminarRol(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(new RolUsuarioDTO());
            var application = new ApplicationResponse<RolUsuarioDTO>();

            //act
            var result = _controller.EliminarRol(UsuarioClient.idusuario, UsuarioClient.idrol);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar rol de usuario excepción")]
        public void EliminarRolUsuarioCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarRol(It.IsAny<Guid>(), It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarRol(It.IsAny<Guid>(), It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}
