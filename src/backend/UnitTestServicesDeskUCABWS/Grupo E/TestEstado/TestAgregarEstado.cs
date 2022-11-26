using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestDepartamento
{
    [TestClass]
    public class TestAgregarEstadoADepartamento
    {
        Mock<IDataContext> context;
        private readonly DepartamentoDAO DepartamentoService;
        private readonly GrupoDAO GrupoService;
        private IMapper mapper;

        public TestAgregarEstadoADepartamento()
        {

            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);
            context = new Mock<IDataContext>();
            GrupoService = new GrupoDAO(context.Object);
            DepartamentoService = new DepartamentoDAO(context.Object,mapper);
            context.SetupDbContextData();
        }

        //Test camino feliz para hacer el consultar estado

        [TestMethod]
        public void AgregarEstadoADepartamentoCreadoTest()
        {
            var arrange = new Departamento()
            {
                id = Guid.Parse("19c117f4-9c2a-49b1-a633-969686e0b57e"),
                nombre = "Almacen de Electronica",
                descripcion = "Lugar donde se guardan todos los recursos de la empresa",
                fecha_creacion = DateTime.UtcNow,
                fecha_ultima_edicion = DateTime.UtcNow,
                fecha_eliminacion = null,
            };

            context.Setup(a => a.DbContext.SaveChanges());

            DepartamentoService.AgregarEstadoADepartamentoCreado(arrange);

            

        }
    }
}
