using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestTipoEstado
{
    [TestClass]
    public class TestAgregarEstadoATipoEstado
    {
        Mock<IDataContext> context;
     
        private readonly TipoEstadoService TipoEstadoDAO;
        private IMapper mapper;
        public TestAgregarEstadoATipoEstado()
        {
            context = new Mock<IDataContext>();
            TipoEstadoDAO= new TipoEstadoService(context.Object);
            context.SetupDbContextData();
        }

        //Test camino feliz para hacer el consultar estado

        [TestMethod]
        public void AgregarEstadoATipoEstadoTest()
        {
            var arrange = new Tipo_Estado()
            {
                Id = new Guid("A4D4417A-9A80-4EC2-B01E-02F57EB31144")
            };

            context.Setup(a => a.DbContext.SaveChanges());

           TipoEstadoDAO.AgregarEstadoATipoEstadoCreado(arrange);

        }

    }
}





