using System.Security.Claims;
using Chat.Room.Infrastructure.Configuration.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Room.Application.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginSession _loginSession;

        public HomeController(ILoginSession loginSession)
        {
            _loginSession = loginSession;
        }

        public Task<IActionResult> Index()
        {
            ViewBag.Username = _loginSession.Username;
            return Task.FromResult<IActionResult>(View());
        }
    }
}