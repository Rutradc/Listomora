using Listomora.Domain.Enums;
using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Listomora.Infrastructure.Seeds
{
    public class IngredientSeed : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(
                new
                {
                    Id = new Guid("cae52516-7547-4d4e-a289-358fd8891a98"),
                    Name = "Pommes de terre",
                    IsPublic = true,
                    Category = IngredientCategory.CEREALS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("e5bebf1e-bd35-448c-a1a2-941e55687ff5"),
                    Name = "Viande de veau",
                    IsPublic = false,
                    Category = IngredientCategory.MEAT,
                    CreatorId = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                },
                new
                {
                    Id = new Guid("1ed84abe-4c15-458f-82b8-a5a9bc34b5b5"),
                    Name = "Filet de saumon",
                    IsPublic = true,
                    Category = IngredientCategory.FISH_AND_SEAFOODS,
                    CreatorId = new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"),
                },
                new
                {
                    Id = new Guid("82a56879-1d59-40f6-8a20-75cdcd2fe686"),
                    Name = "Emmental rapé",
                    IsPublic = true,
                    Category = IngredientCategory.DAIRY_PRODUCTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("97505262-64f9-4444-83cf-67c93d8161d5"),
                    Name = "Blanc de poulet",
                    IsPublic = false,
                    Category = IngredientCategory.MEAT,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("97796814-4f88-40a6-8d3d-98f46135be41"),
                    Name = "Sel",
                    IsPublic = true,
                    Category = IngredientCategory.CONDIMENTS,
                    CreatorId = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                },
                new
                {
                    Id = new Guid("16c4a654-0f04-40eb-a23e-9d580c7062a8"),
                    Name = "Poivre",
                    IsPublic = false,
                    Category = IngredientCategory.CONDIMENTS,
                    CreatorId = new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"),
                },
                new
                {
                    Id = new Guid("3d11a56b-1b6a-4581-940a-36eb4c25d01c"),
                    Name = "Spaghetti",
                    IsPublic = true,
                    Category = IngredientCategory.CEREALS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
                );
        }
    }
}
