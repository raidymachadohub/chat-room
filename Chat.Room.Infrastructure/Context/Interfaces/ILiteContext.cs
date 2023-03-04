using Chat.Room.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chat.Room.Infrastructure.Context.Interfaces
{
    public interface ILiteContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken token);
        ValueTask<EntityEntry> AddAsync(
            object entity,
            CancellationToken cancellationToken);
        EntityEntry Update(object entity);
    }
}

