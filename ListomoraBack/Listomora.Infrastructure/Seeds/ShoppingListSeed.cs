using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Seeds
{
    public class ShoppingListSeed : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasData(
                new ShoppingList
                {
                    Id = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    Name = "Liste de courses du samedi 28 mars",
                    IsTemplate = false,
                    IsDone = false,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
            );
        }
    }
}
