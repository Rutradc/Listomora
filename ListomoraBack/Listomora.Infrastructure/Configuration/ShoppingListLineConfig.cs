using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Configuration
{
    public class ShoppingListLineConfig : IEntityTypeConfiguration<ShoppingListLine>
    {
        public void Configure(EntityTypeBuilder<ShoppingListLine> builder)
        {
            builder.Property(a => a.Amount)
                .IsRequired();
            builder.Property(a => a.Unit) // deviendra UnitTypeEnum
                .IsRequired();
            builder.Property(a => a.Price)
                .IsRequired();

            //constraints
            builder.HasKey(s => new { s.ArticleId, s.ShoppingListId }).HasName("PK_ShoppingListLine");

            //relations
            // shoppingListLine <> article
            builder.HasOne(s => s.Article)
                .WithMany(a => a.ShoppingListLines)
                .HasForeignKey(s => s.ArticleId)
                .HasConstraintName("FK_ShoppingListLine_Article");
            // shoppingListLine <> shoppingList
            builder.HasOne(sll => sll.ShoppingList)
                .WithMany(sl => sl.ShoppingListLines)
                .HasForeignKey(sll => sll.ShoppingListId)
                .HasConstraintName("FK_ShoppingListLine_ShoppingList");
        }
    }
}
