using Chat.Room.Infrastructure.Configuration.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Chat.Room.Infrastructure.Configuration
{
    public class LoginSession : ILoginSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Token { get; private set; }
        public string Username { get; private set; }

        public LoginSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            Username = httpContextAccessor.HttpContext.User.Identity?.Name ?? "";
        }
    }
}