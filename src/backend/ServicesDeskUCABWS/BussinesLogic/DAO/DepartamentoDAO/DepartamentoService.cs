using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public class DepartamentoService : IDepartamentoDAO
    {
        private readonly DataContext _dataContext;

        //Constructor
        public DepartamentoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<DepartamentoDTO> ConsultarDepartamentos()
        {
            try
            {
                var lista = _dataContext.Departamentos.Select(
                    d => new DepartamentoDTO
                    {
                        id = d.Id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion,
                        fecha_eliminacion = d.fecha_eliminacion

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
