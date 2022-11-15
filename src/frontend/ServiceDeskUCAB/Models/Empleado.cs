using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
    public class Empleado : Usuario
    {
        public List<Ticket> Lista_Ticket { get; set; }
        public Cargo Cargo { get; set; }
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }

        public Empleado(int cedula, string primer_nombre, string primer_apellido, string segundo_apellido, DateTime fecha_nacimiento, char gender, string correo, string segundo_nombre)
        {
            Id = Guid.NewGuid();
            this.cedula = cedula;
            this.primer_nombre = primer_nombre;
            this.segundo_nombre = segundo_nombre;
            this.primer_apellido = primer_apellido;
            this.segundo_apellido = segundo_apellido;
            this.fecha_nacimiento = fecha_nacimiento;
            this.gender = gender;
            this.correo = correo;
        }


    }


}
