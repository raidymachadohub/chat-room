using Chat.Room.Domain.Model;

namespace Chat.Room.Service.Services.Interfaces
{
    public interface ITokenService
    {
        string Generate(Login login);
    }
}

