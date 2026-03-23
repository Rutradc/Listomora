using Listomora.Domain.Enums;
using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Seeds
{
    public class ShoppingListLineSeed : IEntityTypeConfiguration<ShoppingListLine>
    {
        public void Configure(EntityTypeBuilder<ShoppingListLine> builder)
        {
            #region Liste de courses du samedi 28 mars
            builder.HasData(
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_1,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Articles.CocaCola,
                    Amount = 6,
                    Unit = UnitTypeEnum.LITER,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_2,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Articles.Mouchoirs,
                    Amount = 2,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_3,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Articles.ChipsKroky,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_4,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Articles.PizzaSurgelee,
                    Amount = 2,
                    Unit = UnitTypeEnum.BOX,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_5,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Ingredients.Pomme,
                    Amount = 6,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_6,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Ingredients.Fraise,
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi28Mars_7,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi28Mars,
                    ArticleId = SeedIds.Ingredients.Lait,
                    Amount = 2,
                    Unit = UnitTypeEnum.LITER,
                }
            );
            #endregion

            #region Liste de courses de mercredi soir prochain
            builder.HasData(
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_1,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Macaroni,
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_2,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Poulet,
                    Amount = 600,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_3,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Tomate,
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_4,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Mozzarella,
                    Amount = 2,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_5,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.HuileOlive,
                    Amount = 50,
                    Unit = UnitTypeEnum.CENTILITER,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_6,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Persil,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_7,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Pain,
                    Amount = 1,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeMercredi_8,
                    ShoppingListId = SeedIds.ShoppingLists.ListeMercredi,
                    ArticleId = SeedIds.Ingredients.Oeufs,
                    Amount = 12,
                    Unit = UnitTypeEnum.UNIT,
                }
            );
            #endregion

            #region Liste de courses du samedi 7 mars
            builder.HasData(
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_1,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Saucisses,
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_2,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.HaricotsVerts,
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_3,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Carotte,
                    Amount = 6,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_4,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Moutarde,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_5,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Thon,
                    Amount = 2,
                    Unit = UnitTypeEnum.CAN,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_6,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Beurre,
                    Amount = 250,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeSamedi7Mars_7,
                    ShoppingListId = SeedIds.ShoppingLists.ListeSamedi7Mars,
                    ArticleId = SeedIds.Ingredients.Sucre,
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                }
            );
            #endregion

            #region Liste de courses habituelle
            builder.HasData(
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_1,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Articles.SavonPalmolive,
                    Amount = 1,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_2,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Articles.Dentifrice,
                    Amount = 1,
                    Unit = UnitTypeEnum.BOX,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_3,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Articles.PilesAAA,
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_4,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Ingredients.Chocolat,
                    Amount = 200,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_5,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Ingredients.Peche,
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_6,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Ingredients.Cannelle,
                },
                new ShoppingListLine
                {
                    Id = SeedIds.ShoppingListLines.ListeHabituelle_7,
                    ShoppingListId = SeedIds.ShoppingLists.ListeHabituelle,
                    ArticleId = SeedIds.Ingredients.Crevettes,
                    Amount = 300,
                    Unit = UnitTypeEnum.GRAM,
                }
            );
            #endregion
        }
    }
}