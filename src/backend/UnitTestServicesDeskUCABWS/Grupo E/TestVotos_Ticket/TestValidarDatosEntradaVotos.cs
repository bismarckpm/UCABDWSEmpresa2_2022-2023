using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class TestValidarDatosEntradaVotos
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotoDAO;
        private readonly Mock<ITicketDAO> ticketDAO;

        public TestValidarDatosEntradaVotos()
        {
            ticketDAO = new Mock<ITicketDAO>();
            context = new Mock<IDataContext>();
            VotoDAO = new Votos_TicketService(context.Object,ticketDAO.Object);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void ElComentarioNoPuedeSerMayorA300Caracteres()
        {
            Votos_TicketDTOCreate entrada=new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelentefnwekjnwelkfmwel;fmwel;fmwel;fmew;lfmlwefmwel;fmwel;fmw;elmfwel;fmewl;fmwe;flmwef;lwemf;wemfw;epfmweomfwepofmpoefmowefmowemfowefoejfoewfjweofjewpofjewopfjweopfjwepofjowefjwepofjwepofmewmpofkwepofkoekfopwekfpowekfopwekfopewkfpwekfwepokfewpofkeowpkfeowpkweopkedkwe;dflkweo;pfdkweo;pkfeowpfkweofkop;efopfk",
                voto = "Aprobado"
            };
            ExceptionsControl actualException = null;

            //act
            try
            {
                VotoDAO.ValidarDatosEntradaVotos(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual(actualException.Mensaje,ErroresVotos.COMENTARIO_FUERA_RANGO);
        }
        [TestMethod]
        public void TicketNoEncontradoEnLaBD()
        {
            Votos_TicketDTOCreate entrada = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E98-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobado"
            };
            ExceptionsControl actualException = null;

            //act
            try
            {
                VotoDAO.ValidarDatosEntradaVotos(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual(actualException.Mensaje, ErroresVotos.ERROR_TICKET_DESC);
        }

        [TestMethod]
        public void UsuarioNoEncontradoEnLaBD()
        {
            Votos_TicketDTOCreate entrada = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "C035D2FC-C0E2-4AE0-9668-4A3AC66BB81A",
                comentario = "Excelente",
                voto = "Aprobado"
            };
            ExceptionsControl actualException = null;

            //act
            try
            {
                VotoDAO.ValidarDatosEntradaVotos(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual(actualException.Mensaje, ErroresVotos.ERROR_USUARIO_DESC);
        }

        [TestMethod]
        public void VotoNoEncontradoEnLaBD()
        {
            Votos_TicketDTOCreate entrada = new Votos_TicketDTOCreate()
            {
                IdTicket = "132A191C-95AE-4538-8E78-C5EDD3092552",
                IdUsuario = "E40D0211-EA65-49BB-BAEE-E8A5F504F3B1",
                comentario = "Excelente",
                voto = "Aprobado"
            };
            ExceptionsControl actualException = null;

            //act
            try
            {
                VotoDAO.ValidarDatosEntradaVotos(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual(actualException.Mensaje, ErroresVotos.VOTO_NO_PERMITIDO);
        }

        [TestMethod]
        public void TurnoExpiradoEnVotacion()
        {
            Votos_TicketDTOCreate entrada = new Votos_TicketDTOCreate()
            {
                IdTicket = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                IdUsuario = "0F636FB4-7F04-4A2E-B2C2-359B99BE85D1",
                comentario = "Excelente",
                voto = "Aprobado"
            };
            ExceptionsControl actualException = null;
            //act
            try
            {
                VotoDAO.ValidarDatosEntradaVotos(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }
            Assert.IsNotNull(actualException);
            Assert.AreEqual(actualException.Mensaje, ErroresVotos.VOTACION_EXPIRADA);
        }
    }
}
