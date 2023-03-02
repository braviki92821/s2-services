using System.Net;

namespace s2_services.Data
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public object Content { get; set; } = string.Empty;
    }
}
