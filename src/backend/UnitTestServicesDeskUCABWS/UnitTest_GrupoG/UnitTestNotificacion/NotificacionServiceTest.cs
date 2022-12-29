using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestNotificacion
{
    [TestClass]
    public class NotificacionServiceTest
    {
        // readonly Mock<IDataContext> _contextMock;
        private readonly NotificacionService _NotificacionService;


        public NotificacionServiceTest()
        {
            _NotificacionService = new NotificacionService();
        }

//*
//PRUEBAS UNITARIAS PARA REEMPLAZAR ETIQUETAS EN PLANTILLA NOTIFICACION
//*

        [TestMethod(displayName: "Prueba Unitaria para reemplazar las etiquetas en la plantilla notificación")]                    
        public void ReemplazarEtiquetasEmpleadoNotificacionServiceTest()
        {

            var Ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                titulo = "titulo",
                descripcion = "descripcion",
                fecha_creacion = DateTime.Now,
                Estado = new Estado()
                {
                    Id = Guid.NewGuid(),
                    nombre = "nombreEstado",
                    Estado_Padre = new Tipo_Estado()
                    {
                        Id = Guid.NewGuid(),
                        nombre = "nombrePadreEstado"
                    }
                },
                Tipo_Ticket = new TipoTicket_FlujoNoAprobacion()
                {
                    nombre = "nombreTipoTicket"
                },
                Departamento_Destino = new Departamento()
                {
                    nombre = "nombreDepartamento",
                    grupo = new Grupo()
                    {
                        nombre = "nombreGrupo"
                    }
                },
                Prioridad = new Prioridad()
                {
                    nombre = "nombrePrioridad"
                },
                Emisor = new Empleado()
                {
                    Id = Guid.Parse("18f401c9-12aa-460f-80a2-00ff05bb0c06"),
                    primer_nombre = "nombreEmpleado",
                    primer_apellido = "apellidoEmpleado",
                    Cargo = new Cargo()
                    {
                        id = Guid.NewGuid(),
                        nombre_departamental = "nombreDepartamento",
                        descripcion = "descrip",
                        fecha_creacion = DateTime.Now,
                    }
                },
            };

            var Plantilla = new PlantillaNotificacionDTO()
            {
                Id = Guid.NewGuid(),
                Titulo = "tituloPlantilla",
                Descripcion = "@Cargo @Ticket @Estado @Departamento @Grupo @Prioridad @Usuario @TipoTicket @ComentarioVoto",
                TipoEstado = new TipoEstadoDTO()
                {
                    etiqueta = new HashSet<EtiquetaDTO>()
                    {
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Usuario"
                        },
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Departamento"
                        },
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Grupo"
                        }
                    }
                }
            };

            var result = _NotificacionService.ReemplazoEtiqueta(Ticket, Plantilla);
            Assert.AreEqual(result, "@Cargo @Ticket @Estado nombreDepartamento nombreGrupo @Prioridad nombreEmpleado apellidoEmpleado @TipoTicket @ComentarioVoto");
        }

        [TestMethod(displayName: "Prueba Unitaria cuando existe un argumento null al reemplazar las etiquetas")]
        public void ReemplazarEtiquetasNullReferenceExceptionServiceTest()
        {

            var Ticket = new Ticket();
            var Plantilla = new PlantillaNotificacionDTO();

            Assert.ThrowsException<ExceptionsControl>(() => _NotificacionService.ReemplazoEtiqueta(It.IsAny<Ticket>(), It.IsAny<PlantillaNotificacionDTO>()));
        }

//*
//PRUEBAS UNITARIAS PARA REEMPLAZAR ETIQUETAS EN PLANTILLA NOTIFICACION
//*

        [TestMethod(displayName: "Prueba Unitaria al enviar correo exitoso")]       
        public void EnviarCorreoExitosoServiceTest()
        {
            var Plantilla = new PlantillaNotificacionDTO()
            {
                Id = Guid.NewGuid(),
                Titulo = "Titulo email prueba unitaria",
                Descripcion = "Cuerpo del email prueba unitaria"
            };
            var correoDestino = "manueloliv96@gmail.com, 22anthony.monsalve@gmail.com";

            _NotificacionService.EnviarCorreo(Plantilla, correoDestino);
        }

        [TestMethod(displayName: "Prueba Unitaria cuando existe una excepcion al enviar correo")]        
        public void EnviarCorreoExceptionServiceTest()
        {
            Assert.ThrowsException<ExceptionsControl>(() => _NotificacionService.EnviarCorreo(It.IsAny<PlantillaNotificacionDTO>(), It.IsAny<string>()));
        }
    }
}
