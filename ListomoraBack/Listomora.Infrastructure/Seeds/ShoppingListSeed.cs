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
                },
                new ShoppingList
                {
                    Id = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    Name = "Liste de courses de mercredi soir prochain",
                    IsTemplate = false,
                    IsDone = false,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new ShoppingList
                {
                    Id = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    Name = "Liste de courses du samedi 7 mars",
                    IsTemplate = false,
                    IsDone = true,
                    DoneAt = new DateTime(2026, 3, 7, 10, 32, 48),
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new ShoppingList
                {
                    Id = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    Name = "Liste de courses habituelle",
                    IsTemplate = true,
                    IsDone = false,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
            );
        }
    }
}
