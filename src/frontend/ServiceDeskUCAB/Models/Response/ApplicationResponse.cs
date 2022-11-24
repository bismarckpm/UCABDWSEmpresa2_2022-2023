using System.Net;

namespace ServiceDeskUCAB.Models.Response
{
    public class ApplicationResponse<T> where T : class
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Exception { get; set; }
    }
}