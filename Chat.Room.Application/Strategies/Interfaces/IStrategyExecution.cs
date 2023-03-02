using Chat.Room.Shared.FlowControl.Model;
namespace Chat.Room.Application.Strategies.Interfaces
{
    public interface IStrategyExecution 
    {
        Task<Result> ExecuteAsync(string user, string message);
    }
}

