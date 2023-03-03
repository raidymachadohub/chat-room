using Chat.Room.Application.Di;
using Chat.Room.Application.Hubs;
using Chat.Room.Application.Middleware;
using Chat.Room.Infrastructure.Di;
using Chat.Room.Service.Di;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Host.ConfigureServices((hostContext, services) =>
{
    var config = hostContext.Configuration;
    services
        .AddStrategies()
        .AddAutoMapper()
        .AddRepositories()
        .AddServices()
        .AddClients()
        .AddChatSession()
        .AddRabbitMQ()
        .AddHttpClient(config)
        .AddAuthentication(config)
        .AddDbContext(config)
        .AddHttpContextAccessor();
});

var app = builder.Build();

app.UseMiddleware<HeaderMiddleware>();
app.AddMigration();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
