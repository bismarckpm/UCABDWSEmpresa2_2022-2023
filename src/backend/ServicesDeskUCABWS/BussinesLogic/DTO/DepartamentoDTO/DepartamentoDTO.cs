using System;
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

        public Guid id {
            get {return _id; }
            set {_id = value; }
        }
        public string nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string descripcion {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public DateTime fecha_creacion {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
		public DateTime? fecha_ultima_edicion {
            get { return _fecha_ultima_edicion; }
            set { _fecha_ultima_edicion = value; }
        } 
        public DateTime? fecha_eliminacion {
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

        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public DateTime fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        public DateTime? fecha_ultima_edicion
        {
            get { return _fecha_ultima_edicion; }
            set { _fecha_ultima_edicion = value; }
        }
        public DateTime? fecha_eliminacion
        {
            get { return _fecha_eliminacion; }
            set { _fecha_eliminacion = value; }
        }

        [JsonIgnore]
        public Guid? id_grupo { 
            get { return _id_grupo;}
            set { _id_grupo = value; }
        }
    }

   
}