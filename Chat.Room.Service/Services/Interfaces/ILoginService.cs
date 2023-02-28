using Chat.Room.Domain.Model;

namespace Chat.Room.Service.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Login> Insert(Login login);
        Task<Login> Authenticate(Login login);
    }
}
