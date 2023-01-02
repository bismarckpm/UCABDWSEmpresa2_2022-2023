using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.ControllerDepartamento;
using ServicesDeskUCABWS.Controllers.ControllerGrupo;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.GrupoTest
{
	[TestClass]
	public class GrupoControllerTest
	{
		private readonly GrupoController _controller;
		private readonly Mock<IGrupoDAO> _serviceMock;
		//private readonly Mock<IGrupoDAO> _contextMockDG;
		public Grupo grupo = It.IsAny<Grupo>();
		public GrupoDto grupoDto = It.IsAny<GrupoDto>();

		public GrupoControllerTest()
		{
			_serviceMock = new Mock<IGrupoDAO>();
			_controller = new GrupoController(_serviceMock.Object);
		}

		[TestMethod(displayName: "Prueba Unitaria para crear un Grupo sin excepciones")]
		public void CrearGrupo()
		{
			var grupo = new GrupoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,
			};

			//arrange
			_serviceMock.Setup(p => p.AgregarGrupoDao(It.IsAny<Grupo>())).Returns(new GrupoDto());
			var application = new ApplicationResponse<GrupoDto>();

			//act
			var result = _controller.CrearGrupo(grupo);

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion al momento de crear un Grupo")]
		public void ExcepcionCrearGrupo()
		{

			var dept = new GrupoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Interna",

				descripcion = "Cuidando la paz mental",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,
			};

			//arrange
			_serviceMock.Setup(p => p.AgregarGrupoDao(It.IsAny<Grupo>())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.CrearGrupo(dept);

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria Consultar Grupos sin excepciones")]
		public void ConsultarGrupo()
		{
			var dept = new GrupoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,
			};

			//arrange
			_serviceMock.Setup(p => p.ConsultarGruposDao()).Returns(new List<GrupoDto>());
			var application = new ApplicationResponse<List<GrupoDto>>();

			//act
			var result = _controller.ConsultarGrupos();

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria Consultar lista de grupos con excepcion")]
		public void ExcepcionConsultarGrupo()
		{

			var dept = new GrupoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c91"),

				nombre = "Seguridad Externa",

				descripcion = "Externa",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,
			};

			//arrange
			_serviceMock.Setup(p => p.ConsultarGruposDao()).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.ConsultarGrupos();

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria consular un grupo sin excepciones")]
		public void ConsultarGrupoPorID()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			//arrange
			_serviceMock.Setup(p => p.ConsultarPorIdDao(It.IsAny<Guid>())).Returns(new GrupoDto());
			var application = new ApplicationResponse<GrupoDto>();

			//act
			var result = _controller.ConsultarPorID(grupo.id);

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria probar excepcion al consultar un grupo por su ID")]
		public void ExcepcionConsultarGrupoPorID()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c00"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			//arrange
			_serviceMock.Setup(p => p.ConsultarPorIdDao(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.ConsultarPorID(grupo.id);

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria para eliminar un grupo sin excepciones")]
		public void EliminarGrupo()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c90"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			//arrange
			_serviceMock.Setup(p => p.EliminarGrupoDao(It.IsAny<Guid>())).Returns(new GrupoDto());
			var application = new ApplicationResponse<GrupoDto>();

			//act
			var result = _controller.EliminarGrupo(grupo.id);

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria para comprobar excepciones al momento de eliminar un grupo")]
		public void ExcepcionEliminarGrupo()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c00"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			//arrange
			_serviceMock.Setup(p => p.EliminarGrupoDao(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.EliminarGrupo(grupo.id);

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria Controlador para modificar departamento exitoso")]
		public void ActualizarGrupo()
		{
			var grupo = new GrupoDto_Update()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c90"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_ultima_edicion = null
			};

			//arrange
			_serviceMock.Setup(p => p.ModificarGrupoDao(It.IsAny<Grupo>())).Returns(new GrupoDto_Update());
			var application = new ApplicationResponse<GrupoDto_Update>();

			//act
			var result = _controller.ActualizarGrupo(grupo);

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria comprobar excepcion al momento de actualizar un grupo")]
		public void ExcepcionActualizarGrupo()
		{

			var grupo = new GrupoDto_Update()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c00"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_ultima_edicion = null
			};

			//arrange
			_serviceMock.Setup(p => p.ModificarGrupoDao(It.IsAny<Grupo>())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.ActualizarGrupo(grupo);

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria consultar los grupos que no están eliminados")]
		public void ListaGrupoEliminado()
		{
			//arrange
			_serviceMock.Setup(p => p.ConsultarGrupoNoEliminado()).Returns(new List<GrupoDto>());
			var application = new ApplicationResponse<List<GrupoDto>>();

			//act
			var result = _controller.ListaGrupoNoEliminado();

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria comprobar excepcion al momento de consultar los grupos que no están eliminados")]
		public void ExcepcionListaGrupoNoEliminados()
		{

			//arrange
			_serviceMock.Setup(p => p.ConsultarGrupoNoEliminado()).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.ListaGrupoNoEliminado();

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}


		[TestMethod(displayName: "Prueba Unitaria Controlador para modificar departamento por id de grupo exitoso")]
		public void ConsultarDepartamentoPorIDGrupo()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var dept = new DepartamentoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			//arrange
			_serviceMock.Setup(p => p.GetByIdDepartamento(It.IsAny<Guid>())).Returns(new List<DepartamentoDto>());
			var application = new ApplicationResponse<List<DepartamentoDto>>();

			//act
			var result = _controller.ListaDepartamentosGrupo(grupo.id);

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria Controlador para consultar departamento por id de grupo excepcion")]
		public void ExcepcionConsultarDepartamentoPorIDGrupo()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			//arrange
			_serviceMock.Setup(p => p.GetByIdDepartamento(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.ListaDepartamentosGrupo(grupo.id);

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria Controlador para asignar grupo a departamento exitoso")]
		public void AsignarGrupoToDepartamento()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var dept = new DepartamentoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			//arrange
			_serviceMock.Setup(p => p.AsignarGrupoToDepartamento(It.IsAny<Guid>(), dept.id.ToString())).Returns(new List<string>());
			var application = new ApplicationResponse<List<string>>();

			//act
			var result = _controller.AsignarGrupoToDepartamento(grupo.id, dept.id.ToString());

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria Controlador para asignar grupo a departamento excepcion")]
		public void ExcepcionAsignarGrupoToDepartamento()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var dept = new DepartamentoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			//arrange
			_serviceMock.Setup(p => p.AsignarGrupoToDepartamento(It.IsAny<Guid>(), dept.id.ToString())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.AsignarGrupoToDepartamento(grupo.id, dept.id.ToString());

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

		[TestMethod(displayName: "Prueba Unitaria Controlador para editar la relacion de departamentos con grupo de forma exitosa")]
		public void EditarRelacion()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var dept = new DepartamentoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			//arrange
			_serviceMock.Setup(p => p.EditarRelacion(It.IsAny<Guid>(), dept.id.ToString())).Returns(new List<string>());
			var application = new ApplicationResponse<List<string>>();

			//act
			var result = _controller.EditarRelacion(grupo.id, dept.id.ToString());

			//assert
			Assert.AreEqual(application.GetType(), result.GetType());
		}


		[TestMethod(displayName: "Prueba Unitaria Controlador para editar la relacion de departamentos con grupo de forma excepcion")]
		public void ExcepcionEditarRelacion()
		{
			var grupo = new Grupo()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Nuevo Grupo",

				descripcion = "Grupo nuevo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var dept = new DepartamentoDto()
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			//arrange
			_serviceMock.Setup(p => p.EditarRelacion(It.IsAny<Guid>(), dept.id.ToString())).Throws(new ExceptionsControl("", new Exception()));

			//act
			var ex = _controller.EditarRelacion(grupo.id, dept.id.ToString());

			//assert
			Assert.IsNotNull(ex);
			Assert.IsFalse(ex.Success);
		}

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar el nombre de grupo de forma exitosa")]
        public void ConsultarNombreGrupo()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.buscarGrupoNombre(It.IsAny<string>())).Returns(new GrupoDto());
            var application = new ApplicationResponse<GrupoDto>();

            //act
            var result = _controller.ConsultarNombreGrupo(grupo.nombre);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar el nombre de grupo excepcion")]
        public void ExcepcionConsultarNombreGrupo()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.buscarGrupoNombre(It.IsAny<string>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarNombreGrupo(grupo.nombre);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


    }

}