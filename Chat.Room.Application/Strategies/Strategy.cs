using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Application.Strategies
{
    public class Strategy : IStrategy
    {
        public Task<Result> ExecuteAsync(string user, string message)
        {
            throw new NotImplementedException();
        }
    }
}

