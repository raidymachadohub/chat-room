using Chat.Room.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Chat.Room.Infrastructure.Context.Interfaces;

namespace Chat.Room.Infrastructure.Context
{
    public class LiteContext : DbContext, ILiteContext
    {
        public LiteContext(DbContextOptions<LiteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Login>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Login>? Login { get; set; }
    }
}
