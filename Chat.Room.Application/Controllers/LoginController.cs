using AutoMapper;
using Chat.Room.Domain.DTO;
using Chat.Room.Domain.Model;
using Chat.Room.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Room.Application.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _loginService = loginService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult NewLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginDTO loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.username) || string.IsNullOrEmpty(loginDto.password))
                return BadRequest("Username or Password must be not empty");

            var login = _mapper.Map<Login>(loginDto);
            var result = await _loginService.AuthenticateAsync(login);

            if (!result.Success)
                return BadRequest(result);
            
            var token = _tokenService.Generate(result.Value);

            Response.Cookies.Append("_u", token, new CookieOptions
            {
                Path = "/"
            });
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddLogin(LoginDTO loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.username) || string.IsNullOrEmpty(loginDto.password))
                return BadRequest("Username or Password must be not empty");

            var login = _mapper.Map<Login>(loginDto);
            var result = await _loginService.AddOrUpdateAsync(login);

            if (!result.Success)
                return BadRequest(result);

            return View("Index");
        }
    }
}