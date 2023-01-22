using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO
{
    public class DepartamentoDto
    {
        private Guid _id;
        private string _nombre;
        private string _descripcion;
        private DateTime _fecha_creacion;
        private DateTime? _fecha_ultima_edicion;
        private DateTime? _fecha_eliminacion;

        public Guid Id {
            get {return _id; }
            set {_id = value; }
        }
        public string Nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public DateTime Fecha_creacion {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
		public DateTime? Fecha_ultima_edicion {
            get { return _fecha_ultima_edicion; }
            set { _fecha_ultima_edicion = value; }
        } 
        public DateTime? Fecha_eliminacion {
            get { return _fecha_eliminacion; }
            set { _fecha_eliminacion = value; }
        }
    }

    public class DepartamentoDto_Update
    {
        private Guid _id;
        private string _nombre;
        private string _descripcion;
        private DateTime _fecha_creacion;
        private DateTime? _fecha_ultima_edicion;
        private DateTime? _fecha_eliminacion;
        private Guid? _id_grupo;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        public DateTime? Fecha_ultima_edicion
        {
            get { return _fecha_ultima_edicion; }
            set { _fecha_ultima_edicion = value; }
        }
        public DateTime? Fecha_eliminacion
        {
            get { return _fecha_eliminacion; }
            set { _fecha_eliminacion = value; }
        }

        [JsonIgnore]
        public Guid? Id_grupo { 
            get { return _id_grupo;}
            set { _id_grupo = value; }
        }
    }

    public class DepartamentoCargoDTO
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public List<CargoDTOUpdate> Cargo { get; set; }
    }
}