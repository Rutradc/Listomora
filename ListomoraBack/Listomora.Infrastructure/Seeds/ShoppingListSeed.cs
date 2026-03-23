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
                    Id = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    Name = "Liste de courses du samedi 28 mars",
                    IsTemplate = false,
                    IsDone = false,
                    CreatorId = SeedIds.Users.JohnCena,
                },
                new ShoppingList
                {
                    Id = SeedIds.ShoppingLists.ListeMercredi,
                    Name = "Liste de courses de mercredi soir prochain",
                    IsTemplate = false,
                    IsDone = false,
                    CreatorId = SeedIds.Users.JohnCena,
                },
                new ShoppingList
                {
                    Id = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    Name = "Liste de courses du samedi 7 mars",
                    IsTemplate = false,
                    IsDone = true,
                    DoneAt = new DateTime(2026, 3, 7, 10, 32, 48),
                    CreatorId = SeedIds.Users.JohnCena,
                },
                new ShoppingList
                {
                    Id = SeedIds.ShoppingLists.ListeHabituelle,
                    Name = "Liste de courses habituelle",
                    IsTemplate = true,
                    IsDone = false,
                    CreatorId = SeedIds.Users.JohnCena,
                }
            );
        }
    }
}