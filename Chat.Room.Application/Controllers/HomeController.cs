using Microsoft.AspNetCore.Mvc;

namespace Chat.Room.Application.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
               
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
