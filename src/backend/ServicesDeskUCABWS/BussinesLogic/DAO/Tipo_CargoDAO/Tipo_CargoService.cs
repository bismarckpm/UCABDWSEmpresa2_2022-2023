using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO
{
    public class Tipo_CargoService : ITipo_CargoDAO
    {
        private readonly DataContext _dataContext;

        //Constructor
        public Tipo_CargoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Tipo_CargoDTOSearch> ConsultarCargos()
        {
            try
            {
                var lista = _dataContext.Tipos_Cargos.Select(
                    d => new Tipo_CargoDTOSearch
                    {
                        id = d.Id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        nivel_jerarquia = d.nivel_jerarquia


                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }
}
