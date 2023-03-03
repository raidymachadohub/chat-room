using Chat.Room.Application.Strategies.Interfaces;
using Chat.Room.Shared.FlowControl.Enum;
using Chat.Room.Shared.FlowControl.Model;

namespace Chat.Room.Application.Strategies
{
    public class StrategyExecution : IStrategyExecution
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<string, Func<IServiceScope, IStrategy>> _strategies =
            new()
            {
                { "COMMON", scope => scope.ServiceProvider.GetRequiredService<ICommonStrategy>() },
                { "STOCK_BOT", scope => scope.ServiceProvider.GetRequiredService<IStockStrategy>() },
                { "INCORRECT_COMMAND", scope => scope.ServiceProvider.GetRequiredService<IErrorStrategy>() }
            };

        public StrategyExecution(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Result> ExecuteAsync(string user, string message)
        {
            var key = TreatmentMessage(message);

            if (!_strategies.TryGetValue(key, out var getStrategy))
            {
                return Result.Fail(new Error(ErrorType.Business, "Command incorrect in selected strategy"));
            }

            using var scope = _serviceProvider.CreateScope();
            var strategy = getStrategy(scope);
            await strategy.ExecuteAsync(user, message);

            return Result.Ok();
        }

        private static string TreatmentMessage(string message)
        {
            if (message.Contains("/stock="))
                return "STOCK_BOT";
            if (message.Contains('/'))
                return "INCORRECT_COMMAND";
            else
                return "COMMON";
        }
    }
}