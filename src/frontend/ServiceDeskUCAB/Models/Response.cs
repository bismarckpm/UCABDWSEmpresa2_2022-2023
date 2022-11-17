using System.Net;

namespace ServiceDeskUCAB.Models
{
    public class ApplicationResponse<T> where T : class
    {
        public string? message { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public T data { get; set; }
        public bool success { get; set; } = true;
        public string? exception { get; set; }
    }
}
