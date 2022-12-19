using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO
{
    public class Tipo_CargoDTOSearch
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string nivel_jerarquia { get; set; } = string.Empty;
    }
}
