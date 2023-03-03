using Chat.Room.Application.Hubs;
using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Service.Services.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Strategies
{
    public class StockStrategy : IStockStrategy
    {
        private readonly IStockService _stockService;
        private readonly IHubContext<ChatHub> _hubContext;
        
        public StockStrategy(IStockService stockService,
                             IHubContext<ChatHub> hubContext)
        {
            _stockService = stockService;
            _hubContext = hubContext;
        }
        public async Task<Result> ExecuteAsync(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message + "\n  - SEARCHING...");
            await _stockService.GetStockAsync(message);
            return Result.Ok();
        }
    }
}

