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
                new { Id = SeedIds.Ingredients.PommesDeTerre, Name = "Pommes de terre", IsPublic = true, Category = IngredientCategory.CEREALS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.ViandeVeau, Name = "Viande de veau", IsPublic = false, Category = IngredientCategory.MEAT, CreatorId = SeedIds.Users.CristianoRonaldo },
                new { Id = SeedIds.Ingredients.Saumon, Name = "Filet de saumon", IsPublic = true, Category = IngredientCategory.FISH_AND_SEAFOODS, CreatorId = SeedIds.Users.LionelMessi },
                new { Id = SeedIds.Ingredients.Emmental, Name = "Emmental rapé", IsPublic = true, Category = IngredientCategory.DAIRY_PRODUCTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.BlancPoulet, Name = "Blanc de poulet", IsPublic = false, Category = IngredientCategory.MEAT, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Sel, Name = "Sel", IsPublic = true, Category = IngredientCategory.CONDIMENTS, CreatorId = SeedIds.Users.CristianoRonaldo },
                new { Id = SeedIds.Ingredients.Poivre, Name = "Poivre", IsPublic = false, Category = IngredientCategory.CONDIMENTS, CreatorId = SeedIds.Users.LionelMessi },
                new { Id = SeedIds.Ingredients.Spaghetti, Name = "Spaghetti", IsPublic = true, Category = IngredientCategory.CEREALS, CreatorId = SeedIds.Users.JohnCena }
            );
            #endregion

            #region SeedForShoppingList
            builder.HasData(
                new { Id = SeedIds.Ingredients.HaricotsVerts, Name = "Haricots verts", IsPublic = true, Category = IngredientCategory.LEGUMES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Cannelle, Name = "Cannelle", IsPublic = true, Category = IngredientCategory.CONDIMENTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Moutarde, Name = "Moutarde", IsPublic = true, Category = IngredientCategory.CONDIMENTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Fraise, Name = "Fraise", IsPublic = true, Category = IngredientCategory.FRUITS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Pomme, Name = "Pomme", IsPublic = true, Category = IngredientCategory.FRUITS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Tomate, Name = "Tomate", IsPublic = true, Category = IngredientCategory.VEGETABLES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Brocoli, Name = "Brocoli", IsPublic = true, Category = IngredientCategory.VEGETABLES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Mozzarella, Name = "Mozzarella", IsPublic = true, Category = IngredientCategory.DAIRY_PRODUCTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Poulet, Name = "Poulet", IsPublic = true, Category = IngredientCategory.MEAT, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Saucisses, Name = "Saucisses", IsPublic = true, Category = IngredientCategory.MEAT, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Carotte, Name = "Carotte", IsPublic = true, Category = IngredientCategory.VEGETABLES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.HuileOlive, Name = "Huile d'olive", IsPublic = true, Category = IngredientCategory.FATS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Beurre, Name = "Beurre", IsPublic = true, Category = IngredientCategory.FATS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Thon, Name = "Thon", IsPublic = true, Category = IngredientCategory.FISH_AND_SEAFOODS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Lait, Name = "Lait", IsPublic = true, Category = IngredientCategory.BEVERAGES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Chocolat, Name = "Chocolat", IsPublic = true, Category = IngredientCategory.SWEET_PRODUCTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Sucre, Name = "Sucre", IsPublic = true, Category = IngredientCategory.SWEET_PRODUCTS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Crevettes, Name = "Crevettes", IsPublic = true, Category = IngredientCategory.FISH_AND_SEAFOODS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Peche, Name = "Pêche", IsPublic = true, Category = IngredientCategory.FRUITS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Pain, Name = "Pain", IsPublic = true, Category = IngredientCategory.BAKED_AND_PASTRIES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Oeufs, Name = "Œufs", IsPublic = true, Category = IngredientCategory.EGGS, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Persil, Name = "Persil", IsPublic = true, Category = IngredientCategory.HERBS_AND_SPICES, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Ingredients.Macaroni, Name = "Macaroni", IsPublic = true, Category = IngredientCategory.CEREALS, CreatorId = SeedIds.Users.JohnCena }
            );
            #endregion
        }
    }
}