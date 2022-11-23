using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System.Diagnostics;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoI.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestUsuario
{
    [TestClass]
    public class UsuarioServiceTest
    {

        private readonly UsuarioDAO _userService;
        private readonly Mock<IDataContext> _contextMock;

        public UsuarioServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            _userService = new UsuarioDAO(_contextMock.Object);
            _contextMock.SetupDataContextUser();
        }

        [TestMethod(displayName: "Prueba unitaria exitosa para consultar usuario")]
        public void ConsultarUsurioUnitTest()
        {
            var result = _userService.ObtenerUsuarios();
            Assert.IsTrue(result.Count > 0);

        }
        [TestMethod(displayName: "Prueba unitaria para consultar usuario por ID ")]
        public void ConsultarUsurioByID()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");

            var result = _userService.consularUsuarioID(id);

            Assert.AreEqual(result.Id , id );
        }

        [TestMethod(displayName:"Prueba unitaria cuando no exista el  usuario  consultado por ID")]
        public void NoExisteUsuarioPorIDTest()
        {
            Assert.ThrowsException<ExceptionsControl>(() => _userService.consularUsuarioID(new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC122")));
        }

        [TestMethod(displayName: "Prueba unitaria cuando un usuario coloque una clave o un usuario invalido")]
        public void LoginExeption()
        {

            //Assert.ThrowsException<ExceptionsControl>(() => _userService.consularUsuarioID();
        }
    }
}
