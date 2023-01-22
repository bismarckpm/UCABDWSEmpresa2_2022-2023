using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{
    [TestClass]
    public class TestAgregarVoto
    {
        Mock<IDataContext> context;
        private readonly Votos_TicketService VotosTicketDAO;
        private readonly ITicketDAO ticketDAO;

        public TestAgregarVoto()
        {
            context = new Mock<IDataContext>();
            VotosTicketDAO = new Votos_TicketService(context.Object, ticketDAO);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizAgregarVoto()
        {
            //arrange
            var usuario1 = new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")
            {

                Cargo = new Cargo("Jefe D1", "Descripccion C1")
                {
                    id = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                    Departamento = new Departamento("Departamento1", "Descripcion1")
                    {
                        id = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87"),
                        grupo = new Grupo("Grupo1", "Grupo1")

                    }
                    //Tipo_Cargo = ListaTipoCargo[0]
                }
            };
            var entrada = new List<Votos_Ticket>() {
                new Votos_Ticket()
                {
                    IdTicket = Guid.Parse("EC1DDF25-80AF-47AF-AA24-A5B159C5A90F"),
                    Empleado = usuario1,
                    IdUsuario = usuario1.Id,
                    voto = "Pendiente"
                },
                new Votos_Ticket()
                {

                }
            };
            //act

            var result = VotosTicketDAO.AgregarVoto(entrada);
            //assert
            Assert.IsTrue(result);
        }
    }
}
