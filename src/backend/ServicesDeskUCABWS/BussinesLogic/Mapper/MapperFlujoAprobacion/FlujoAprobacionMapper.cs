using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperFlujoAprobacion
{
    public class FlujoAprobacionMapper
    {
        public static Flujo_AprobacionDTOSearch MapperTipoTicketToTipoTicketDTOSearch(Flujo_Aprobacion flujo)
        {
            var FlujoDTO = new Flujo_AprobacionDTOSearch();
            FlujoDTO.IdCargo = flujo.IdCargo.ToString();
            FlujoDTO.OrdenAprobacion = flujo.OrdenAprobacion;
            FlujoDTO.Minimo_aprobado_nivel = flujo.Minimo_aprobado_nivel;
            FlujoDTO.Maximo_Rechazado_nivel = flujo.Maximo_Rechazado_nivel;
            if (flujo.Cargo != null)
            {
                FlujoDTO.Cargo = CargoMapper.MapperEntityToDto(flujo.Cargo);
            }
            return FlujoDTO;
        }

        public static List<Flujo_AprobacionDTOSearch> MapperListaFlujoEntityToFlujoDTO(List<Flujo_Aprobacion> flujoAprobacion)
        {
            var FlujoDTO = new List<Flujo_AprobacionDTOSearch>();
            foreach (Flujo_Aprobacion item in flujoAprobacion)
            {
                FlujoDTO.Add(MapperTipoTicketToTipoTicketDTOSearch(item));
            }
            return FlujoDTO;
        }
    }
}
