using Chat.Room.Domain.Model;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Service.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Result<Login>> AddOrUpdateAsync(Login login);
        Task<Result<Login>> AuthenticateAsync(Login login);
    }
}
