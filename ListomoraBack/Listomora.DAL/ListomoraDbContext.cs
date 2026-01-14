using Listomora.DAL.Configuration;
using Listomora.DAL.Seeds;
using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Listomora.DAL
{
    public class ListomoraDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public ListomoraDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new IngredientConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

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

            modelBuilder.ApplyConfiguration(new ArticleSeed());
            modelBuilder.ApplyConfiguration(new IngredientSeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
        }
    }
}
