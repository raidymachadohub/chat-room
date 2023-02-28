using Chat.Room.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Room.Application.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
