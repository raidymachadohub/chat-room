using System.Security.Claims;
using Chat.Room.Application.Strategies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Room.Application.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStrategyExecution _strategyExecution;
        
        public HomeController(IStrategyExecution strategyExecution)
        {
            _strategyExecution = strategyExecution;
        }

        public async Task<IActionResult> Index()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            ViewBag.Username = identity.Name;
            return View();
        }
    }
}