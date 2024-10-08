using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    internal class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>().ToTable("users");
        }
    }
}
