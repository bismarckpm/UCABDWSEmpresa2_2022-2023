<<<<<<< HEAD
﻿
using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO;
=======
﻿using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;
>>>>>>> 4b6f7c0a7b3933ac418b139414d149f012f3314d
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers
{
    public class PrioridadMapper:Profile
    {
        public PrioridadMapper()
        {
            CreateMap<Prioridad, PrioridadDTO>();
<<<<<<< HEAD
            CreateMap<PrioridadDTO,Prioridad>();
=======
            CreateMap<PrioridadDTO, Prioridad>();

            //CreateMap<List<Prioridad>, PrioridadDTO>();
            //CreateMap<PrioridadDTO, List<Prioridad>>();
>>>>>>> 4b6f7c0a7b3933ac418b139414d149f012f3314d
        }
    }
}
