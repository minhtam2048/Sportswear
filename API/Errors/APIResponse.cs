using System;

namespace API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Unauthorized user",
                404 => "Resource not found",
                500 => "Internal Server Error",
                _ => null,
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}