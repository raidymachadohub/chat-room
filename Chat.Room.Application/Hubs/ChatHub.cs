using Chat.Room.Application.Strategies.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IStrategyExecution _strategyExecution;

        public ChatHub(IStrategyExecution strategyExecution)
        {
            _strategyExecution = strategyExecution;
        }
        
        public async Task SendMessage(string user, string message)
        {
            await _strategyExecution.ExecuteAsync(user, message);
        }
    }
}
