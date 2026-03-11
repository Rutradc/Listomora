using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Seeds
{
    public class ShoppingListLineSeed : IEntityTypeConfiguration<ShoppingListLine>
    {
        public void Configure(EntityTypeBuilder<ShoppingListLine> builder)
        {
            builder.HasData(
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"),
                    Amount = 1,
                    Unit = "pièce",
                }    
            );
        }
    }
}
