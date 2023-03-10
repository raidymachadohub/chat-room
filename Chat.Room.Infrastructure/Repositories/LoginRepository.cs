using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Context.Interfaces;
using Chat.Room.Infrastructure.Repositories.Interfaces;
using Chat.Room.Shared.FlowControl.Enum;
using Chat.Room.Shared.FlowControl.Model;
using Microsoft.EntityFrameworkCore;

namespace Chat.Room.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ILiteContext _context;

        public LoginRepository(ILiteContext context)
        {
            _context = context;
        }

        public async Task<Result<Login>> AddOrUpdateAsync(Login login)
        {
            if (_context.Set<Login>() == null)
                return Result.Fail<Login>(new Error(ErrorType.Business,
                    $"Context Login is null"));

            var existLogin = await _context.Set<Login>()
                .FirstOrDefaultAsync(log => log.Username == login.Username);

            if (existLogin == null)
            {
                await _context.AddAsync(login, CancellationToken.None);
                await _context.SaveChangesAsync(CancellationToken.None);
                return Result.Ok(login);
            }

            var loginWithPassword = await _context.Set<Login>()
                .FirstOrDefaultAsync(log => log.Username == login.Username && log.Password == login.Password);

            if (loginWithPassword == null)
                return Result.Fail<Login>(new Error(ErrorType.Business,
                    $"Username: {existLogin.Username} already used, try another"));

            _context.Update(existLogin);
            await _context.SaveChangesAsync(CancellationToken.None);
            return Result.Ok(login);
        }

        public async Task<Result<Login>> AuthenticateAsync(Login login)
        {
            if (_context.Set<Login>() == null)
                return Result.Fail<Login>(new Error(ErrorType.Business, "Object Login is null."));

            var userLogin = await _context.Set<Login>()
                .FirstOrDefaultAsync(log => log.Username == login.Username && log.Password == login.Password);

            if (userLogin == null)
                return Result.Fail<Login>(new Error(ErrorType.Business, "User or password is incorrect."));

            return Result.Ok(userLogin);
        }
    }
}