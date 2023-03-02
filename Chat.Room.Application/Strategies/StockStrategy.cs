using Chat.Room.Application.Hubs;
using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Strategies
{
    public class StockStrategy : IStockStrategy
    {
        private readonly IHubContext<ChatHub> _hubContext;
        //ServiceStock

        public StockStrategy(IHubContext<ChatHub> hubContext)
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

