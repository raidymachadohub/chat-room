using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Facade.Interfaces;
using Chat.Room.Service.Services.Interfaces;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Service.Services
{
    public class StockService : IStockService
    {
        private readonly IRabbitMQFacade _rabbitMqFacade;

        public StockService(IRabbitMQFacade rabbitMqFacade)
        {
            _rabbitMqFacade = rabbitMqFacade;
        }

        public async Task<Result<Stock>> GetStockAsync(string stockCode)
        {
            return await _rabbitMqFacade.SendMessageAsync(new Stock() { Symbol = stockCode });
        }
    }
}