using System;
using System.Net;

namespace ServicesDeskUCAB.Dtos
{
    public class GenericResponse
    {
        public string Message { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public object Data { get; set; }
        public bool success { get; set; }
        public string exception { get; set; }
    }
}

