using Chat.Room.Application.Hubs;
using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Strategies
{
    public class ErrorStrategy : IErrorStrategy
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ErrorStrategy(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<Result> ExecuteAsync(string user, string message)
        {
            message = $"This command {message} is wrong, try with /stock=";
            user = "BOT";
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            return Result.Ok();
        }
    }
}

