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
            #region BaseSeed
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
            #endregion
            #region SeedForShoppingList
            builder.HasData(
                new
                {
                    Id = new Guid("ac07af80-640a-4270-9d48-62f8c9b84df6"),
                    Name = "Haricots verts",
                    IsPublic = true,
                    Category = IngredientCategory.LEGUMES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("2145139b-64b4-475e-ba84-5efe83d53d8b"),
                    Name = "Cannelle",
                    IsPublic = true,
                    Category = IngredientCategory.CONDIMENTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("4c500d54-1468-4a8c-81f5-ff846fb36b3d"),
                    Name = "Moutarde",
                    IsPublic = true,
                    Category = IngredientCategory.CONDIMENTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("4a5bda61-ac90-4faf-9ae1-139f81a17eb6"),
                    Name = "Fraise",
                    IsPublic = true,
                    Category = IngredientCategory.FRUITS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("b09ea0c6-b53a-4a70-bff7-56dcfc5bb2d0"),
                    Name = "Pomme",
                    IsPublic = true,
                    Category = IngredientCategory.FRUITS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("e6f1fd6a-abb7-4d84-bca8-aeff139dc88c"),
                    Name = "Tomate",
                    IsPublic = true,
                    Category = IngredientCategory.VEGETABLES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("eaa7d8cb-f6ac-40b6-9cfe-6250acb41907"),
                    Name = "Brocoli",
                    IsPublic = true,
                    Category = IngredientCategory.VEGETABLES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("46703052-e35c-4582-85a8-418f284e0ec8"),
                    Name = "Mozzarella",
                    IsPublic = true,
                    Category = IngredientCategory.DAIRY_PRODUCTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("9e736920-7440-4376-b485-1f192e0d7470"),
                    Name = "Poulet",
                    IsPublic = true,
                    Category = IngredientCategory.MEAT,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("c762d216-d6ab-43b6-bfe7-cab995c5aea9"),
                    Name = "Saucisses",
                    IsPublic = true,
                    Category = IngredientCategory.MEAT,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("794f67c2-7afb-495e-8570-6daad6cb4a0a"),
                    Name = "Carotte",
                    IsPublic = true,
                    Category = IngredientCategory.VEGETABLES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("fcf05aed-90e9-47a0-b9b9-09af9bf0f2b9"),
                    Name = "Huile d'olive",
                    IsPublic = true,
                    Category = IngredientCategory.FATS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("48f07af2-eefb-4097-a479-cc50a3117851"),
                    Name = "Beurre",
                    IsPublic = true,
                    Category = IngredientCategory.FATS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("121a810d-3904-4cf1-9af4-063a2e56b62b"),
                    Name = "Thon",
                    IsPublic = true,
                    Category = IngredientCategory.FISH_AND_SEAFOODS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("edf88fdd-0117-4aa4-b3a5-17be26c913f9"),
                    Name = "Lait",
                    IsPublic = true,
                    Category = IngredientCategory.BEVERAGES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("1dd4a5f7-f93f-42ed-919d-c677f0dc0e7f"),
                    Name = "Chocolat",
                    IsPublic = true,
                    Category = IngredientCategory.SWEET_PRODUCTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("21d579a9-b2ae-4434-b7d5-45201001bca1"),
                    Name = "Sucre",
                    IsPublic = true,
                    Category = IngredientCategory.SWEET_PRODUCTS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("c65e7d76-8af8-4e1c-b89e-3102248e73a6"),
                    Name = "Crevettes",
                    IsPublic = true,
                    Category = IngredientCategory.FISH_AND_SEAFOODS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("aac50be3-c2ea-4642-a3d9-81f58299e012"),
                    Name = "Pêche",
                    IsPublic = true,
                    Category = IngredientCategory.FRUITS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("d35633e3-34cb-48d2-aedc-5a65271357d2"),
                    Name = "Pain",
                    IsPublic = true,
                    Category = IngredientCategory.BAKED_AND_PASTRIES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("3d956419-cd5b-41c5-9b2a-d7e5a990c838"),
                    Name = "Œufs",
                    IsPublic = true,
                    Category = IngredientCategory.EGGS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("924c8c5b-9684-4b77-b5d0-80b0f1cf8b30"),
                    Name = "Persil",
                    IsPublic = true,
                    Category = IngredientCategory.HERBS_AND_SPICES,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("ff0cdcf7-aee0-4b9e-b520-8d0fb3b93047"),
                    Name = "Macaroni",
                    IsPublic = true,
                    Category = IngredientCategory.CEREALS,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
            );
            #endregion
        }
    }
}
