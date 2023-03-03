using Chat.Room.Domain.Model;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Service.Services.Interfaces
{
    public interface IStockService
    {
        Task<Result<Stock>> GetStockAsync(string stockCode);
    }
}

