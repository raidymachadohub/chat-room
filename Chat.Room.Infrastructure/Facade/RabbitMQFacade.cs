using System.Text;
using Chat.Room.Domain.Constants;
using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Facade.Interfaces;
using Chat.Room.Shared.FlowControl.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Chat.Room.Infrastructure.Facade
{
    public class RabbitMQFacade : IRabbitMQFacade
    {
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMQFacade()
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            };
        }

        public async Task<Result<Stock>> SendMessageAsync(Stock stock)
        {
            var message = JsonConvert.SerializeObject(stock);

            using var conn = _connectionFactory.CreateConnection();
            using var channel = conn.CreateModel();

            channel.QueueDeclare(queue: RabbitMQConstant.QueueNameBot,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: RabbitMQConstant.QueueNameBot,
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(message));
            
            return Result.Ok(stock);
        }
    }
}

