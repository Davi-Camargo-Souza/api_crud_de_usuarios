using Microsoft.EntityFrameworkCore;
using SeboScrob.Domain.Entities;

namespace SeboScrob.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
