using Chat.Room.Domain.Model;
using Chat.Room.Infrastructure.Context;
using Chat.Room.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Room.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LiteContext _context;

        public LoginRepository(LiteContext context)
        {
            _context = context;
        }

        public async Task<Login> Insert(Login login)
        {
            await _context.AddAsync(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task<Login> Authenticate(Login login)
        {
            if (_context.Login == null)
                throw new Exception("Object reference Login is null.");

            var userLogin = await _context.Login.AsQueryable()
                                        .Where(log => log.Username == login.Username && log.Password == login.Password)
                                        .FirstOrDefaultAsync();

            if (userLogin == null)
                throw new Exception("User or password is incorrect.");

            return userLogin;
        }
    }
}
