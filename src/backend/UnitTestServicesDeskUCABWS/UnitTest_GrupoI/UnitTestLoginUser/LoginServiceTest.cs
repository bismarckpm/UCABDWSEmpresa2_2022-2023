using Microsoft.Extensions.Options;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoI.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestLoginUser
{
    [TestClass]
    public class LoginServiceTest
    {
        private readonly UserLoginDAO _service;
        private readonly Mock<IDataContext> _contextMock;
        private readonly Mock<IOptions<AppSettings>> _appSettings;



        public LoginServiceTest()

        {
            _appSettings = new Mock<IOptions<AppSettings>>();
            _contextMock = new Mock<IDataContext>();
            AppSettings AppSettingsTest = new AppSettings() { Secreto = "ucabdeskucab1234" };
            _appSettings.Setup(ap => ap.Value).Returns(AppSettingsTest);
            _service = new UserLoginDAO(_contextMock.Object, _appSettings.Object);
            _contextMock.SetupDataContextLoginUser();
        }

        [TestMethod(displayName: "Prueba unitaria para el servicio de inicio de sesión")]
        public void UserLoginTest()
        {
            var user = new UserLoginDto
            {
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop"
            };

            var dataResponse = _service.UserLogin(user);

            Assert.AreEqual(dataResponse.correo, user.correo);

        }
        [TestMethod(displayName: "Prueba unitaria para el servicio de inicio de sesión cuando el usuario no es valido")]
        public void UserLoginTestUserNotValid()
        {
            var user = new UserLoginDto
            {
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuip"
            };
            Assert.ThrowsException<ExceptionsControl>(() => _service.UserLogin(user));

        }
    }
}
