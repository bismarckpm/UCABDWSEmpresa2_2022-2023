using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.Tipo_Cargo_Test
{
	[TestClass]
	public class TipoCargoDAOTest
	{
		/*private readonly Tipo_CargoDAO _TipoCargoDAO;
		private readonly Tipo_CargoDAO _TipoCargoDAO_CTC;

		private readonly Mock<IDataContext> _contextMock;
		private readonly Mock<IDataContext> _contextMockCTC;

		public TipoCargoDAOTest()
		{
			_contextMock = new Mock<IDataContext>();
			_contextMockCTC = new Mock<IDataContext>();
			_TipoCargoDAO = new Tipo_CargoDAO(_contextMock.Object);
			_TipoCargoDAO_CTC = new Tipo_CargoDAO(_contextMockCTC.Object);
			_contextMock.SetUpContextDataTipoCargo();
			_contextMockCTC.SetUpContextDataCargo_TipoCargo();
		}

		/*[TestMethod(displayName: "Prueba Unitaria para agregar un nuevo tipo de cargo")]
		public void RegistrarTipoCargoTest()
		{
			//arrange
			var request = new Tipo_Cargo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d35"),

				nombre = "Un tipo de cargo que funciona",

				descripcion = "Es un tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = null

			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _TipoCargoDAO.AgregarTipo_CargoDAO(request);

			Assert.AreEqual(request.nombre, "Un tipo de cargo que funciona");
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar la excepcion general al registrar un Tipo de cargo")]
		public void ExceptionGeneralRegistrarTipoCargoTest()
		{
			//arrange
			var request = new Tipo_Cargo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d15"),

				nombre = "Segundo Tipo Cargo Nuevo",

				descripcion = "Es otro tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = DateTime.Now.Date

			};

			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.AgregarTipo_CargoDAO(request));
		}

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar que el nombre tipo cargo ya está registrado")]
		public void ExcepcionCondicionalRegistrarTipoCargoTest()
		{
			//arrange
			var request = new Tipo_Cargo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d35"),

				nombre = "Un segundo tipo de cargo que funciona",

				descripcion = "Es un tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = null

			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _TipoCargoDAO.AgregarTipo_CargoDAO(request);

			Assert.AreNotEqual(request.nombre, result.nombre);
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para consultar los tipos de cargos registrados")]
		public void ConsultarTipoCargosTest()
		{
			var result = _TipoCargoDAO.ConsultarTipo_Cargos();
			Assert.AreEqual(result.Count(), _contextMock.Object.Tipos_Cargos.ToList().Count());
		}

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion al no tener ningún tipo de cargo registrado")]
		public void ExceptionConsultarTipósCargosTest()
		{
			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.ConsultarTipo_Cargos());
		}
		*/
		/*[TestMethod(displayName: "Prueba Unitaria para consultar los tipos de cargos por su ID")]
		public void ConsultarTiposCargosIDTest()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d15"),

				nombre = "Segundo Tipo Cargo Nuevo",

				descripcion = "Es otro tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = DateTime.Now.Date

			};

			var result = _TipoCargoDAO.ConsultarPorID(request.id);
			Assert.AreEqual(result.id, request.id);
		}

		[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion al consultar por ID los tipos de cargos")]
		public void ExceptionConsultarTiposCargosIDTest()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d10"),

				nombre = "Segundo Tipo Cargo Nuevo",

				descripcion = "Es otro tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = DateTime.Now.Date
			};

			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.ConsultarPorID(request.id));
		}

		[TestMethod(displayName: "Prueba Unitaria para modificar un tipo de cargo")]
		public void ModificarTipoCargoTest()
		{
			//arrange
			var request = new Tipo_Cargo
			{
					id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d18"),

					nombre = "Tercero Tipo Cargo Nuevo",

					descripcion = "Es otro tipo de cargo",

					fecha_creacion = DateTime.MinValue,

					fecha_ult_edic = DateTime.Now.Date,

					fecha_eliminacion = null
			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _TipoCargoDAO.actualizarTipo_Cargo(request);

			Assert.AreEqual(request.nombre, "Tercero Tipo Cargo Nuevo");
		}

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion general al modificar un tipo de cargo por campos vacíos")]
		public void ExcepcionGeneralModificarTipoCargoTest()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d18"),

				nombre = "",

				descripcion = "",

				fecha_creacion = DateTime.MinValue,

				fecha_ult_edic = DateTime.Now.Date,

				fecha_eliminacion = null
			};

			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.actualizarTipo_Cargo(request));
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar excecipon al modificar un tipo de cargo falla por campos nulos")]
		public void ExcepcionDBUpdateModificarTipoCargo()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d18"),

				nombre = null,

				descripcion = "Es otro tipo de cargo",

				fecha_creacion = DateTime.MinValue,

				fecha_ult_edic = null,

				fecha_eliminacion = null
			};

			_contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.actualizarTipo_Cargo(request));
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria Eliminar un tipo de cargo por su ID")]
		public void EliminarTipoCargoPorID()
		{
			var request = new Tipo_Cargo
			{

				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d18")

			};

			var obj = new Tipo_CargoDto();
			_contextMock.Setup(set => set.DbContext.SaveChanges());
			var result = _TipoCargoDAO.EliminarTipo_Cargo(request.id);
			Assert.IsInstanceOfType(obj, result.GetType());
		}

		[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion al momento de eliminar un típo de cargo por su ID")]
		public void ExcepcionGeneralEliminarTipoCargoPorID()
		{
			var data = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d99")

			};

			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.EliminarTipo_Cargo(data.id));
		}

		/*[TestMethod(displayName: "Prueba Unitaria para mostrar los tipos de cargos que no están eliminados")]
		public void ConsultarTipoCargosNoEliminados()
		{

			_contextMock.Setup(set => set.DbContext.SaveChanges());

			var result = _TipoCargoDAO.ConsultarTipoCargoNoEliminado();

			Assert.AreEqual(result.Count(), 2);
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion general al no existir ningún tipo de cargo que haya sido eliminado")]
		public void ExcepcionGeneralConsultarTipoCargosNoEliminados()
		{
			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.ConsultarTipoCargoNoEliminado());
		}

		[TestMethod(displayName: "Prueba Unitaria para comprobar la existencia de un tipo de cargo")]
		public void ExisteTipoCargo()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d35"),

				nombre = "Un tipo de cargo que funciona",

				descripcion = "Es un tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = null
			};

			_contextMock.Setup(set => set.DbContext.SaveChanges());
			var result = _TipoCargoDAO.ExisteTipo(request);
			Assert.IsTrue(result);
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para comprobar excepcion al existir un tipo cargo")]
		public void ExcepcionExisteTipoCargo()
		{

			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2d15"),

				nombre = "Segundo Tipo Cargo Nuevo",

				descripcion = "Es otro tipo de cargo",

				fecha_creacion = DateTime.Now.Date,

				fecha_eliminacion = DateTime.Now.Date
			};

			_contextMock.Setup(p => p.Tipos_Cargos).Throws(new Exception(""));
			Assert.ThrowsException<ExceptionsControl>(() => _TipoCargoDAO.ExisteTipo(request));
		}*/

		/*[TestMethod(displayName: "Prueba Unitaria para quitar la asociacion de un cargo con un tipo")]
		public void QuitarAsociacionCargoTipoCargo()
		{
			var request = new Tipo_Cargo
			{
				id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
			};
		
			_contextMockCTC.Setup(set => set.DbContext.SaveChanges());
			var result = _TipoCargoDAO_CTC.QuitarAsociacion(request.id);
			Assert.IsTrue(result);
		}*/
	}

}
