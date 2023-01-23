using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
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

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestUsuario
{
    [TestClass]
    public class UsuarioServiceControlerTest
    {
        private readonly UsuarioController _controller;
        private readonly Mock<IUsuarioDAO> _serviceMock;
        private readonly Mock<IUserLoginDAO> _serviceMockLogin;
        public UsuarioServiceControlerTest()
        {
            _serviceMock = new Mock<IUsuarioDAO>();
            _serviceMockLogin = new Mock<IUserLoginDAO>();  
            _controller = new UsuarioController(_serviceMock.Object, _serviceMockLogin.Object);
        }

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar usuarios")]
        public void ConsultaUsuariosCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerUsuarios()).Returns(new List<Usuario>());
            var application = new ApplicationResponse<List<Usuario>>();

            //act
            var result = _controller.ConsultarUsuarios();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar usuarios excepcion")]
        public void ConsultaRolesCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerUsuarios()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarUsuarios();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar usuario en especifico exitoso")]
        public void GetEtiquetaByGuidCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.consularUsuarioID(It.IsAny<Guid>())).Returns(new Usuario());
            var application = new ApplicationResponse<Usuario>();

            //act
            var result = _controller.GetByTipoUsuarioId(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar un usuario en especificoo excepcion")]
        public void GetUsuarioByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.consularUsuarioID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTipoUsuarioId(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Administrador exitoso")]
        public void CrearAdminstradorCtrlTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarAdminstrador(It.IsAny<Usuario>())).Returns(new Administrador());
            var application = new ApplicationResponse<Administrador>();

            //act
            var result = _controller.CrearAdministrador(requestUserAdmin);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Administrador excepcion")]
        public void CrearAdministradorCtrlExceptionTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarAdminstrador(It.IsAny<Usuario>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearAdministrador(requestUserAdmin);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Adminstrador excepcion correo repetido")]
        public void CrearAdministradorCtrlExceptionDbUpdateExceptionTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarAdminstrador(It.IsAny<Usuario>())).Throws(new ExceptionsControl("", new DbUpdateException()));

            //act
            var ex = _controller.CrearAdministrador(requestUserAdmin);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Cliente exitoso")]
        public void CrearClienteCtrlTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarCliente(It.IsAny<Usuario>())).Returns(new Cliente());
            var application = new ApplicationResponse<Cliente>();

            //act
            var result = _controller.CrearCliente(requestUserAdmin);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Cliente excepcion")]
        public void CrearClienteCtrlExceptionTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarCliente(It.IsAny<Usuario>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearCliente(requestUserAdmin);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Empleado exitoso")]
        public void CrearEmpleadoCtrlTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarEmpleado(It.IsAny<Usuario>())).Returns(new Empleado());
            var application = new ApplicationResponse<Empleado>();

            //act
            var result = _controller.CrearEmpleado(requestUserAdmin);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear un Empleado excepcion")]
        public void CrearEmpleadoCtrlExceptionTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarEmpleado(It.IsAny<Usuario>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearEmpleado(requestUserAdmin);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Empleado excepcion correo repetido")]
        public void CrearEmpleadoCtrlExceptionDbUpdateExceptionTest()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };
            //arrange
            _serviceMock.Setup(p => p.AgregarEmpleado(It.IsAny<Usuario>())).Throws(new ExceptionsControl("", new DbUpdateException()));

            //act
            var ex = _controller.CrearEmpleado(requestUserAdmin);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para recuperar contraseña")]
        public void RecuperarClaveTest()
        {
            var requestUserAdmin = new UserRecoveryDTO
            {
                email = "diegocumares@gmail.com"
            };
            //arrange
            _serviceMock.Setup(p => p.RecuperarClave(It.IsAny<string>())).Returns("Correo enviado");
            var application = new ApplicationResponse<Empleado>();

            //act
            var result = _controller.RecuperarClave(requestUserAdmin);

            //assert
            Assert.AreEqual(result.Message, "Correo enviado");
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para recuperar contraseña Exception")]
        public void RecuperarClaveExeptionTest()
        {
            var requestUserAdmin = new UserRecoveryDTO
            {
                email = "diegocumares@gmail.com"
            };
            //arrange
            _serviceMock.Setup(p => p.RecuperarClave(It.IsAny<string>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var result = _controller.RecuperarClave(requestUserAdmin);

            //assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar usuario exitoso")]
        public void EliminarUsuario()
        {
            var requestUserAdmin = new UsuarioDto
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
            };


            //arrange
            _serviceMock.Setup(p => p.eliminarUsuario(It.IsAny<Guid>())).Returns(new UsuarioDto());
            var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.EliminarUsuario(requestUserAdmin.Id);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar usuario exception")]
        public void EliminarUsuarioException()
        {
            //arrange
            _serviceMock.Setup(p => p.eliminarUsuario(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarUsuario(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        //Consultar Empleado

        [TestMethod]
        public void ConsultarEmpleado()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerEmpleados()).Returns(new List<UsuarioGeneralDTO>());
            var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.ConsultarEmpleados();

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void ConsultarEmpleadoException()
        {
            //arrange
            _serviceMock.Setup(p => p.ObtenerEmpleados()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarEmpleados();

            //assert
            Assert.AreEqual(false, ex.Success);
        }

        //Obtener Empleado por Id
        [TestMethod]
        public void GetByTipoEmpleadoId()
        {
            //arrange
            _serviceMock.Setup(p => p.consularEmpleadoID(It.IsAny<Guid>())).Returns(new Empleado());
            //var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.GetByTipoEmpleadoId(new Guid());

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void GetByTipoEmpleadoIdException()
        {
            //arrange
            _serviceMock.Setup(p => p.consularEmpleadoID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTipoEmpleadoId(new Guid());

            //assert
            Assert.AreEqual(false, ex.Success);
        }

        //login
        [TestMethod]
        public void UserLogin()
        {
            //arrange
            _serviceMockLogin.Setup(p => p.UserLogin(It.IsAny<UserLoginDto>())).Returns(new UserResponseLoginDTO());
            //var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.UserLogin(new UserLoginDto());

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void UserLoginException()
        {
            //arrange
            _serviceMockLogin.Setup(p => p.UserLogin(It.IsAny<UserLoginDto>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.UserLogin(new UserLoginDto());

            //assert
            Assert.AreEqual(false, ex.Success);
        }

        //Asignar Cargo
        [TestMethod]
        public void AsignarCargo()
        {
            //arrange
            _serviceMock.Setup(p => p.AsignarCargo(It.IsAny<UsuarioDTOAsignarCargo>())).Returns(new UsuarioDTOAsignarCargo());
            //var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.AsignarCargo(new UsuarioDTOAsignarCargo());

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void AsignarCargoException()
        {
            //arrange
            _serviceMock.Setup(p => p.AsignarCargo(It.IsAny<UsuarioDTOAsignarCargo>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.AsignarCargo(new UsuarioDTOAsignarCargo());

            //assert
            Assert.AreEqual(false, ex.Success);
        }

        //Revocar Cargo
        [TestMethod]
        public void RevocarCargo()
        {
            //arrange
            _serviceMock.Setup(p => p.RevocarCargo(It.IsAny<Guid>())).Returns("Respuesta");
            //var application = new ApplicationResponse<UsuarioDto>();

            //act
            var result = _controller.RevocarCargo(new Guid());

            //assert
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void RevocarCargoException()
        {
            //arrange
            _serviceMock.Setup(p => p.RevocarCargo(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.RevocarCargo(new Guid());

            //assert
            Assert.AreEqual(false, ex.Success);
        }

    }
}
