using ServicesDeskUCABWS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Familia_Ticket
    {
        [Required]
        private Guid Id { get; set; }
        [Required]
        private List<Ticket> Lista_Ticket { get; set; }
    }
}
