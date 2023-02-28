using Chat.Room.Application.Hubs;
using Chat.Room.Infrastructure.Di;
using Chat.Room.Service.Di;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Host.ConfigureServices((hostContext, services) =>
{
    var config = hostContext.Configuration;
    services
        .AddAutoMapper()
        .AddRepositories()
        .AddServices()
        .AddAuthentication(config)
        .AddDbContext(config);
});

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
