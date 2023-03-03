using Chat.Room.Domain.Model;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Infrastructure.Client.Interfaces
{
    public interface IStockClient
    {
        Task<Result<Stock>> GetStockAsync(string stockCode);
    }
}