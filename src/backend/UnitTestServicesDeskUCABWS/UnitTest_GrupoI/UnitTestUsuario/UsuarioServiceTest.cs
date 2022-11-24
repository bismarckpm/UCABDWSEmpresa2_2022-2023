using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
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


        [TestMethod(displayName: "Prueba Unitaria intentar eliminar un usuario que no existe")]
        public void EliminarUsuarioExeptionTest()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() =>  _userService.eliminarUsuario(id));

        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar un usuario")]
        public void EliminarPlantillaCtrlExceptionTest()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            var obj = new UsuarioDto();
            var result = _userService.eliminarUsuario(id);
            Assert.IsInstanceOfType(obj, result.GetType());

        }

        /*[TestMethod(displayName: "Prueba Unitaria para logeo satisfactorio")]
        public void LoginTest()
        {

        }*/



    }
}
