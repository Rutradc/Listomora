using Listomora.DAL.Configuration;
using Listomora.DAL.Seeds;
using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Listomora.DAL
{
    public class ListomoraDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public ListomoraDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfig());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(EntityBase.CreatedAt))
                        .HasDefaultValueSql("GETUTCDATE()")
                        .ValueGeneratedOnAdd();
                }
            }

            modelBuilder.ApplyConfiguration(new ArticleSeed());
        }
    }
}
