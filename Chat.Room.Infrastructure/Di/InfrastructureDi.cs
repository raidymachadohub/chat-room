using Chat.Room.Infrastructure.Context;
using Chat.Room.Infrastructure.Repositories;
using Chat.Room.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Chat.Room.Infrastructure.Di
{
    [ExcludeFromCodeCoverage]
    public static class InfrastructureDi
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddTransient<ILoginRepository, LoginRepository>();
        
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChatRoomDB");
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<LiteContext>(options => options.UseSqlite(connectionString));

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration.GetSection("Key:JWT").Value;

            if (string.IsNullOrEmpty(key))
                throw new Exception("JWT:Key is empty on AppSettings.");

            services
              .AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
        
        public static IHost AddMigration(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            
            var services = scope.ServiceProvider;
            
            var context = services.GetRequiredService<LiteContext>();
            
            context.Database.Migrate();
            
            return host;
        }
    }
}
