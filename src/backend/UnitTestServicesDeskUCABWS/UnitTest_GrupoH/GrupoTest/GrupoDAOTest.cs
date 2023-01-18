using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.GrupoTest
{
	[TestClass]
	public class GrupoDAOTest
	{
		private readonly GrupoDAO _grupoDAO;
		private readonly GrupoDAO _grupoDAODG;
		private readonly Mock<IDataContext> _contextMock;
		private readonly Mock<IDataContext> _contextMockDG;

		public GrupoDAOTest()
		{
			_contextMock = new Mock<IDataContext>();
			_contextMockDG = new Mock<IDataContext>();
			_grupoDAO = new GrupoDAO(_contextMock.Object);
			_grupoDAODG = new GrupoDAO(_contextMockDG.Object);

			_contextMock.SetUpContextDataGrupo();
			_contextMockDG.SetUpContextDataDepartamentoYGrupo();
		}

		[TestMethod(displayName: "Prueba Unitaria para agregar un Grupo")]
		public void AgregarGrupoTest()
		{
			//arrange
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Grupo Nuevo",

				descripcion = "Es un grupo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _grupoDAO.AgregarGrupoDao(request);

			Assert.AreEqual(request.nombre, "Grupo Nuevo");
		}

		[TestMethod(displayName: "Prueba Unitaria para agregar un Grupo Condicional")]
		public void AgregarGrupoTestIf()
		{
			//arrange
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Grupo Nuevo 2",

				descripcion = "Es un grupo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _grupoDAO.AgregarGrupoDao(request);

			Assert.AreNotEqual(request.nombre, result.Nombre);
		}

		[TestMethod(displayName: "Prueba Unitaria para agregar un Grupo con excepcion")]
		public void AgregarGrupoTestExceptionGeneral()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

				nombre = "",

				descripcion = "Es un grupo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			_contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.AgregarGrupoDao(request));
		}

		[TestMethod(displayName: "Prueba Unitaria para consultar grupos por ID")]
		public void ConsultarGruposPorIDTest()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "La vida es bella",

				descripcion = "Es un grupo",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null
			};

			var result = _grupoDAO.ConsultarPorIdDao(request.id);
			Assert.AreEqual(result.Id, request.id);
		}

		[TestMethod(displayName: "Prueba Unitaria para excepcion al consultar grupos por ID")]
		public void ConsultarGruposTestExceptionID()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,
			};

			_contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.ConsultarPorIdDao(request.id));
		}

		[TestMethod(displayName: "Eliminar grupo por ID")]
		public void EliminarGrupoPorID()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")

			};

			var obj = new GrupoDto();
			_contextMockDG.Setup(set => set.DbContext.SaveChanges());
			var result = _grupoDAODG.EliminarGrupoDao(request.id);
			Assert.IsInstanceOfType(obj, result.GetType());
		}

		[TestMethod(displayName: "Excepcion de eliminar Grupo por ID")]
		public void ExcepcionEliminarGrupoPorID()
		{
			var data = new Grupo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88")

			};

			_contextMock.Setup(p => p.Grupos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.EliminarGrupoDao(data.id));
		}

	/*	[TestMethod(displayName: "Prueba Unitaria para modificar un Grupo")]
		public void ModificarGrupoTest()
		{
			//arrange
			var request = new Grupo
			{

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Grupo Nuevo",

                descripcion = "Es un grupo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _grupoDAO.ModificarGrupoDao(request);

			Assert.AreEqual(request.nombre, request.nombre);
		}*/

		[TestMethod(displayName: "Prueba Unitaria para modificar un grupo Condicional")]
		public void ModificarGrupoTestIf()
		{
			//arrange
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Seguridad Errada",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = DateTime.Now.Date,

				fecha_eliminacion = null

			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _grupoDAO.ModificarGrupoDao(request);

			Assert.AreNotEqual(request.nombre, result.Nombre);
		}

		[TestMethod(displayName: "Prueba Unitaria modificar grupo con campo vacio")]
		public void ExcepcionDBUpdateModificarGrupo()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Seguridad Errada",

				descripcion = null,

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};
			_contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.ModificarGrupoDao(request));
		}

		[TestMethod(displayName: "Prueba Unitaria para editar un departamento excepcion general")]
		public void ExcepcionGeneralModificarGrupo()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c83"),

				nombre = "",

				descripcion = "Seguridad",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			_contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.ModificarGrupoDao(request));
		}

		[TestMethod(displayName: "Prueba Unitaria para consultar los grupos no eliminados")]
		public void MostrarGruposNoEliminados()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Seguridad Errada",

				descripcion = null,

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _grupoDAO.ConsultarGrupoNoEliminado();

			Assert.AreEqual(result.Count(), 1);
		}

		[TestMethod(displayName: "Prueba Unitaria para mostrar excepcion general de los grupos no eliminados")]
		public void ExcepcionMostrarGrupoNoEliminados()
		{
			_contextMock.Setup(p => p.Grupos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.ConsultarGrupoNoEliminado());
		}

		[TestMethod(displayName: "Prueba Unitaria para varificar la existencia de un Grupo")]
		public void ExisteGrupo()
		{
			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Grupo Nuevo",

				descripcion = "Descripcion",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());
			var result = _grupoDAO.ExisteGrupo(request);
			Assert.IsTrue(result);
		}

		[TestMethod(displayName: "Prueba Unitaria para verificar  de departamento con excepcion")]
		public void ExcepcionExisteGrupo()
		{

			var request = new Grupo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

				nombre = "Grupo Errado",

				descripcion = "Descripcion",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null

			};
			_contextMock.Setup(p => p.Grupos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.ExisteGrupo(request));
		}

		[TestMethod(displayName: "Prueba Unitaria para consultar departamentos por ID de grupo")]
		public void ConsultarDepartamentosPorIDGrupo()
		{

			var grupo = new Grupo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
			};

			
			var result = _grupoDAODG.DepartamentosAsociados(grupo.id);
			Assert.AreEqual(result.Count(), 1);

		}

		[TestMethod(displayName: "Excepcion Prueba Unitaria para consultar departamentos por ID de grupo")]
		public void ExcepcionConsultarDepartamentosPorIDGrupo()
		{

			var grupo = new Grupo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c30")
			};

		    _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.DepartamentosAsociados(grupo.id));

		}

        [TestMethod(displayName: "Prueba Unitaria para asociar grupos a departamentos")]
        public void AsignarGrupoADepartamento()
        {

            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _grupoDAODG.AsignarGrupoToDepartamento(request.id, request.id.ToString());

            Assert.AreEqual(result.Count(), 1);
		}

		[TestMethod(displayName: "Prueba Unitaria para asociar grupos a departamentos excepcion")]
		public void ExcepcionAsignarGrupoADepartamento()
		{

			var request = new Departamento
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,

				id_grupo = null

			};

			_contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.AsignarGrupoToDepartamento(request.id, request.id.ToString()));
		}

		[TestMethod(displayName: "Prueba Unitaria para editar relacion de los departamentos con los grupos con lista de IDs de Departamentos vacios")]
		public void EditarRelacionPrimerCondicional()
		{

			_contextMockDG.Setup(set => set.DbContext.SaveChanges());
			var result = _grupoDAODG.EditarRelacion(It.IsAny<Guid>(), String.Empty);
			Assert.AreEqual(result.Count, 1);
		}

		[TestMethod(displayName: "Prueba Unitaria para editar relacion de los departamentos con los grupos con lista de IDs de Departamentos asignado")]
		public void EditarRelacionElse()
		{

			var grupo = new Grupo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
			};

			var request = new Departamento
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,

				id_grupo = grupo.id

			};


			_contextMockDG.Setup(set => set.DbContext.SaveChanges());
			var result = _grupoDAODG.EditarRelacion(It.IsAny<Guid>(), request.id.ToString());
			Assert.AreEqual(result.Count, 1);
		}

		[TestMethod(displayName: "Prueba Unitaria para la excepcion de editar relacion de los departamentos con los grupos")]
		public void ExcepcionEditarRelacion()
		{
			var grupo = new Grupo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
			};

			var request = new Departamento
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

				nombre = "Seguridad Ambiental",

				descripcion = "Cuida el ambiente",

				fecha_creacion = DateTime.Now.Date,

				fecha_ultima_edicion = null,

				fecha_eliminacion = null,

				id_grupo = grupo.id

			};

			_contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _grupoDAO.EditarRelacion(grupo.id, request.id.ToString()));
		}

        [TestMethod(displayName: "Prueba Unitaria para consultar un grupo por nombre de forma exitosa")]
        public void BuscarGrupoNombre()
        {

            var grupo = new Grupo
            {
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Grupo Nuevo"
            };


            var result = _grupoDAO.BuscarGrupoNombre(grupo.nombre);
            Assert.AreEqual(result.Nombre, grupo.nombre);

        }

        [TestMethod(displayName: "Excepcion Prueba Unitaria para consultar un grupo por nombre de forma fallida")]
        public void ExcepcionBuscarGrupoNombre()
        {

            var grupo = new Grupo
            {
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Seguridad"
            };

            _contextMock.Setup(p => p.Grupos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _grupoDAODG.BuscarGrupoNombre(grupo.nombre));

        }


    }
}
