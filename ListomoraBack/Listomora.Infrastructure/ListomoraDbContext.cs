using Listomora.Infrastructure.Configuration;
using Listomora.Infrastructure.Seeds;
using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Listomora.Infrastructure
{
    public class ListomoraDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public ListomoraDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new IngredientConfig());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(EntityBase.CreatedAt))
                        .HasColumnType("DateTime2")
                        .HasDefaultValueSql("GETUTCDATE()")
                        .ValueGeneratedOnAdd();
                }
            }

            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new ArticleSeed());
            modelBuilder.ApplyConfiguration(new IngredientSeed());
        }
    }
}
