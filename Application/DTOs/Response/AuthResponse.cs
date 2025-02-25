using Microsoft.AspNetCore.Mvc;

namespace ASbackend.Application.DTOs.Response
{
    public class AuthResponse
    {
        public string Message { get; set; }
        public string AcessToken { get; set; }
        public AuthResponse(string message, string token) 
        {
            AcessToken = token;
            Message = message;
        }
    }
}
