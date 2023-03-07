using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Services
{
    public interface IBooksStoreDbContext
    {
        public DbSet<Author> Authors { get; }
        public DbSet<Book> Books { get; }
        public DbSet<Category> Categories { get; }
        public ChangeTracker ChangeTracker { get;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
