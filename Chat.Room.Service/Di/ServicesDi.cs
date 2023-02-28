using Chat.Room.Service.Services;
using Chat.Room.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Chat.Room.Service.Di
{
    [ExcludeFromCodeCoverage]
    public static class ServicesDi
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddTransient<ILoginService, LoginService>();
    }
}
