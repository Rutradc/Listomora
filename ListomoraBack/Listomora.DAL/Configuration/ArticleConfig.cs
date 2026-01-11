using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.DAL.Configuration
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasDiscriminator<string>("ArticleType")
                .HasValue<Article>("Article")
                .HasValue<Ingredient>("Ingredient");

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(150).IsRequired();

            //constraints
            builder.HasKey(a => a.Id).HasName("PK_Article");
        }
    }
}
