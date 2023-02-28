using Chat.Room.Domain.Model;

namespace Chat.Room.Infrastructure.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> Insert(Login login);
        Task<Login> Authenticate(Login login);
    }
}
