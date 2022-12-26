using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class TestConsultarTicket
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<IVotos_TicketDAO> VotosticketDAO;

        public TestConsultarTicket()
        {
            context = new Mock<IDataContext>();
            VotoDAO = new Votos_TicketService(context.Object);
            context.SetupDbContextData();
        }
        //Test para el servicio consultar votos
        [TestMethod]
        public void CaminoFelizConsultarVotos()
        {
            var entrada = Guid.Parse("C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A");

            var result = VotoDAO.ConsultaVotos(entrada);

            Assert.AreEqual(result.Data.ToList().Count(), 3);
        }

        //Test para el servicio de un excepcion consultar votos 
        [TestMethod]
        public void CaminoFelizConsultarVotosExceptions()
        {
            //arrage
            var entrada = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            var Expected = new ApplicationResponse<List<Votos_Ticket>>()
            {
                Success = false,

            };

            //act
            context.Setup(x => x.Votos_Tickets).Throws(new Exception(""));

            var result = VotoDAO.ConsultaVotos(entrada);

            //assert
            Assert.IsNotNull(result.Exception);
            Assert.IsFalse(result.Success);

        }

        //Test para el servicio consultar votos no pendientes
        [TestMethod]
        public void CaminoFelizConsultarVotosNoPendientes()
        {
            var entrada = Guid.Parse("C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A");

            var result = VotoDAO.ConsultaVotosNoPendientes(entrada);

            Assert.AreEqual(result.Data.ToList().Count(), 0);
        }

        //Test para el servicio de un excepcion consultar votos 
        [TestMethod]
        public void CaminoFelizConsultarVotosNoPendientesExceptions()
        {
            //arrage
            var entrada = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            var Expected = new ApplicationResponse<List<Votos_Ticket>>()
            {
                Success = false,

            };

            //act
            context.Setup(x => x.Votos_Tickets).Throws(new Exception(""));

            var result = VotoDAO.ConsultaVotosNoPendientes(entrada);

            //assert
            Assert.IsNotNull(result.Exception);
            Assert.IsFalse(result.Success);

        }


    }
}
