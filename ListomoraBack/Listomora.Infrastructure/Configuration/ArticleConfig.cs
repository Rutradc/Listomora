using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Configuration
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasDiscriminator<string>("ArticleType")
                .HasValue<Article>("Article")
                .HasValue<Ingredient>("Ingredient");

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.Name)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(a => a.IsPublic)
                .IsRequired();

            //constraints
            builder.HasKey(a => a.Id).HasName("PK_Article");

            //relations
            // article <> user
            builder.HasOne(a => a.Creator)
                .WithMany(d => d.CreatedArticles)
                .HasForeignKey(a => a.CreatorId)
                .HasConstraintName("FK_Article_Creator");
        }
    }
}
