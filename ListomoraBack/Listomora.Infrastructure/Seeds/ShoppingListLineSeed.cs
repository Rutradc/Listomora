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
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("c7e03ae1-353c-4e21-963f-ff906d09506c"),
                    Amount = 6,
                    Unit = UnitTypeEnum.LITER,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("6ef48e96-a40a-4dc5-9432-fe6d85c87bb6"),
                    Amount = 2,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("336ac8ab-c997-4521-a3c1-9aaa5cb86fbb"),
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("d392cdc1-9141-4dc3-ac7e-a4486e2e8774"),
                    Amount = 2,
                    Unit = UnitTypeEnum.BOX,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("b09ea0c6-b53a-4a70-bff7-56dcfc5bb2d0"),
                    Amount = 6,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("4a5bda61-ac90-4faf-9ae1-139f81a17eb6"),
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"),
                    ArticleId = new Guid("edf88fdd-0117-4aa4-b3a5-17be26c913f9"),
                    Amount = 2,
                    Unit = UnitTypeEnum.LITER,
                }
            );
            #endregion

            #region Liste de courses de mercredi soir prochain
            builder.HasData(
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("ff0cdcf7-aee0-4b9e-b520-8d0fb3b93047"),
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("9e736920-7440-4376-b485-1f192e0d7470"),
                    Amount = 600,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("e6f1fd6a-abb7-4d84-bca8-aeff139dc88c"),
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("46703052-e35c-4582-85a8-418f284e0ec8"),
                    Amount = 2,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("fcf05aed-90e9-47a0-b9b9-09af9bf0f2b9"),
                    Amount = 50,
                    Unit = UnitTypeEnum.CENTILITER,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("924c8c5b-9684-4b77-b5d0-80b0f1cf8b30"),
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("d35633e3-34cb-48d2-aedc-5a65271357d2"),
                    Amount = 1,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"),
                    ArticleId = new Guid("3d956419-cd5b-41c5-9b2a-d7e5a990c838"),
                    Amount = 12,
                    Unit = UnitTypeEnum.UNIT,
                }
            );
            #endregion

            #region Liste de courses du samedi 7 mars
            builder.HasData(
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("c762d216-d6ab-43b6-bfe7-cab995c5aea9"),
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("ac07af80-640a-4270-9d48-62f8c9b84df6"),
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("794f67c2-7afb-495e-8570-6daad6cb4a0a"),
                    Amount = 6,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("4c500d54-1468-4a8c-81f5-ff846fb36b3d"),
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("121a810d-3904-4cf1-9af4-063a2e56b62b"),
                    Amount = 2,
                    Unit = UnitTypeEnum.CAN,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("48f07af2-eefb-4097-a479-cc50a3117851"),
                    Amount = 250,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"),
                    ArticleId = new Guid("21d579a9-b2ae-4434-b7d5-45201001bca1"),
                    Amount = 500,
                    Unit = UnitTypeEnum.GRAM,
                }
            );
            #endregion

            #region Liste de courses habituelle
            builder.HasData(
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("d6acb86d-856e-4874-9d64-73a1f3e2f8e9"),
                    Amount = 1,
                    Unit = UnitTypeEnum.PACK,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("a456432d-33d1-44d9-be6a-8599bd02becc"),
                    Amount = 1,
                    Unit = UnitTypeEnum.BOX,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("81bd4a7b-b60c-4e11-8d74-6c641721a928"),
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("1dd4a5f7-f93f-42ed-919d-c677f0dc0e7f"),
                    Amount = 200,
                    Unit = UnitTypeEnum.GRAM,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("aac50be3-c2ea-4642-a3d9-81f58299e012"),
                    Amount = 4,
                    Unit = UnitTypeEnum.UNIT,
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("2145139b-64b4-475e-ba84-5efe83d53d8b"),
                },
                new ShoppingListLine
                {
                    ShoppingListId = new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"),
                    ArticleId = new Guid("c65e7d76-8af8-4e1c-b89e-3102248e73a6"),
                    Amount = 300,
                    Unit = UnitTypeEnum.GRAM,
                }
            );
            #endregion
        }
    }
}
