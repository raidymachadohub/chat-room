using System.Diagnostics.CodeAnalysis;
using Chat.Room.Application.Strategies;
using Chat.Room.Application.Strategies.Interfaces;

namespace Chat.Room.Application.Di
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationDi
    {
        public static IServiceCollection AddStrategies(this IServiceCollection services) =>
            services.AddTransient<IStrategy, Strategy>()
                    .AddTransient<ICommonStrategy, CommonStrategy>()
                    .AddTransient<IStockStrategy, StockStrategy>()
                    .AddTransient<IErrorStrategy, ErrorStrategy>()
                    .AddTransient<IStrategyExecution, StrategyExecution>();
    }
}
