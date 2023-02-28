using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Repositories.Interfaces;
using Chat.Room.Service.Services.Interfaces;

namespace Chat.Room.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Login> Authenticate(Login login)
        {
          return await  _loginRepository.Authenticate(login);
        }

        public async Task<Login> Insert(Login login)
        {
            return await _loginRepository.Insert(login);
        }
    }
}
