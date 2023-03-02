using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Application.Strategies.Interfaces
{
    public interface IStrategy
    {
        Task<Result> ExecuteAsync(string user, string message);
    }
}

