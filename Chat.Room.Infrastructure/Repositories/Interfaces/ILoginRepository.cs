using Chat.Room.Domain.Model;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Infrastructure.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<Result<Login>> AddOrUpdateAsync(Login login);
        Task<Result<Login>> AuthenticateAsync(Login login);
    }
}
