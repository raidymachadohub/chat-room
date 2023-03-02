using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Repositories.Interfaces;
using Chat.Room.Service.Services.Interfaces;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Result<Login>> AuthenticateAsync(Login login)
        {
            return await _loginRepository.AuthenticateAsync(login);
        }

        public async Task<Result<Login>> AddOrUpdateAsync(Login login)
        {
            return await _loginRepository.AddOrUpdateAsync(login);
        }
    }
}