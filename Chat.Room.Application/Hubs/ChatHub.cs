using Chat.Room.Application.Strategies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Room.Application.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IStrategyExecution _strategyExecution;
        private readonly List<string> _connectedClients;

        public ChatHub(IStrategyExecution strategyExecution)
        {
            _strategyExecution = strategyExecution;
            _connectedClients = new List<string>();
        }
        
        public async Task SendMessage(string user, string message)
        {
            await _strategyExecution.ExecuteAsync(user, message);
        }

        public override Task OnConnectedAsync()
        {
            _connectedClients.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _connectedClients.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
