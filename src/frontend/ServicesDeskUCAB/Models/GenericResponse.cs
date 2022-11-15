using System;
using System.Collections.Generic;
using System.Net;

namespace ServicesDeskUCAB.Models
{
	public class GenericResponse
	{
        public string Message { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public List<Prioridad> Data { get; set; }
        public bool success { get; set; }
        public string exception { get; set; }
        
    }
}

