using Chat.Room.Domain.Model;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Infrastructure.Facade.Interfaces
{
    public interface IRabbitMQFacade
    {
        Task<Result<Stock>> SendMessageAsync(Stock stock);
    }
}

