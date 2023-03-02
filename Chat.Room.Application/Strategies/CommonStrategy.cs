using Chat.Room.Application.Hubs;
using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Strategies
{
    public class CommonStrategy : ICommonStrategy
    {
        private readonly IHubContext<ChatHub> _hubContext;
        
        public CommonStrategy(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<Result> ExecuteAsync(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            return Result.Ok();
        }
    }
}
