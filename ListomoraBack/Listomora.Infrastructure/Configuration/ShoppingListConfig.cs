using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Configuration
{
    public class ShoppingListConfig : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.IsTemplate)
                .IsRequired();

            builder.Property(a => a.IsDone)
                .IsRequired();

            builder.Property(a => a.DoneAt)
                .HasColumnType("DateTime2");

            //constraints
            builder.HasKey(a => a.Id).HasName("PK_ShoppingList");

            //relations
            // shoppingListLine <> user
            builder.HasOne(s => s.Creator)
                .WithMany(a => a.CreatedShoppingLists)
                .HasForeignKey(s => s.CreatorId)
                .HasConstraintName("FK_ShoppingList_Creator");
        }
    }
}
