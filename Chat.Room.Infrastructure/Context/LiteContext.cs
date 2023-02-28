using Chat.Room.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Chat.Room.Infrastructure.Context
{
    public class LiteContext : DbContext
    {
        public LiteContext(DbContextOptions<LiteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Login>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        public DbSet<Login>? Login { get; set; }
    }
}
