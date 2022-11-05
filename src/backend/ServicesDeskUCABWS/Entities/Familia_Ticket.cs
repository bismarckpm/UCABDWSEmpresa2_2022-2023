using ServicesDeskUCABWS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class Familia_Ticket
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public List<Ticket> Lista_Ticket { get; set; }
    }
}
