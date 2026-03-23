using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Listomora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DisableDate = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.CheckConstraint("CK_User_Role", "[Role] IN (0,1)");
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArticleType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Creator",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreationToken",
                columns: table => new
                {
                    TokenHash = table.Column<string>(type: "char(64)", maxLength: 64, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreationToken", x => x.TokenHash);
                    table.ForeignKey(
                        name: "FK_CreationToken_AdminCreator",
                        column: x => x.AdminCreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsTemplate = table.Column<bool>(type: "bit", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "DateTime2", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingList_Creator",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListLine_Article",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListLine_ShoppingList",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DisableDate", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), null, "lm10@goat.com", "Lionel", "Messi", "$argon2id$v=19$m=65536,t=3,p=1$YWVyoQbfwHoxu5l30i9t7Q$FRPImLUZdraBt5D024Znmcdg4kQaGYZB6wwYyhb1juk", 1 },
                    { new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, "john@cena.us", "John", "Cena", "$argon2id$v=19$m=65536,t=3,p=1$6nQj2IUSN3802LFUZRG/Iw$vT6joNv++j2GurHfs9/RMakdfiT50gPdfhS47tYJDh0", 0 },
                    { new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), null, "cr7@goat.com", "Cristiano", "Ronaldo", "$argon2id$v=19$m=65536,t=3,p=1$pwImr1dctDCdepWxrMINVA$Kgs/MPisee/BSHXxfAY3j34ORkZFk6IF26QKoh+RLtw", 1 }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("06effa04-6bcf-401f-a091-00b24f6ba8f0"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), true, "Sacs poubelle 30 litres" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("121a810d-3904-4cf1-9af4-063a2e56b62b"), "Ingredient", "FISH_AND_SEAFOODS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Thon" },
                    { new Guid("16c4a654-0f04-40eb-a23e-9d580c7062a8"), "Ingredient", "CONDIMENTS", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), false, "Poivre" },
                    { new Guid("1dd4a5f7-f93f-42ed-919d-c677f0dc0e7f"), "Ingredient", "SWEET_PRODUCTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Chocolat" },
                    { new Guid("1ed84abe-4c15-458f-82b8-a5a9bc34b5b5"), "Ingredient", "FISH_AND_SEAFOODS", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), true, "Filet de saumon" },
                    { new Guid("2145139b-64b4-475e-ba84-5efe83d53d8b"), "Ingredient", "CONDIMENTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Cannelle" },
                    { new Guid("21d579a9-b2ae-4434-b7d5-45201001bca1"), "Ingredient", "SWEET_PRODUCTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Sucre" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("336ac8ab-c997-4521-a3c1-9aaa5cb86fbb"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Chips Kroky paprika" },
                    { new Guid("34a8bda4-f77f-42e5-ba61-2b511985c4db"), "Article", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), true, "Crayons" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("3d11a56b-1b6a-4581-940a-36eb4c25d01c"), "Ingredient", "CEREALS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Spaghetti" },
                    { new Guid("3d956419-cd5b-41c5-9b2a-d7e5a990c838"), "Ingredient", "EGGS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Œufs" },
                    { new Guid("46703052-e35c-4582-85a8-418f284e0ec8"), "Ingredient", "DAIRY_PRODUCTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Mozzarella" },
                    { new Guid("48f07af2-eefb-4097-a479-cc50a3117851"), "Ingredient", "FATS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Beurre" },
                    { new Guid("4a5bda61-ac90-4faf-9ae1-139f81a17eb6"), "Ingredient", "FRUITS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Fraise" },
                    { new Guid("4c500d54-1468-4a8c-81f5-ff846fb36b3d"), "Ingredient", "CONDIMENTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Moutarde" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("6a03f6d7-9160-4d0f-b94b-dbc41d497ec8"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Papier toilette double épaisseur" },
                    { new Guid("6ef48e96-a40a-4dc5-9432-fe6d85c87bb6"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Mouchoirs" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("794f67c2-7afb-495e-8570-6daad6cb4a0a"), "Ingredient", "VEGETABLES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Carotte" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("81bd4a7b-b60c-4e11-8d74-6c641721a928"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Piles AAA" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("82a56879-1d59-40f6-8a20-75cdcd2fe686"), "Ingredient", "DAIRY_PRODUCTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Emmental rapé" },
                    { new Guid("924c8c5b-9684-4b77-b5d0-80b0f1cf8b30"), "Ingredient", "HERBS_AND_SPICES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Persil" },
                    { new Guid("97505262-64f9-4444-83cf-67c93d8161d5"), "Ingredient", "MEAT", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), false, "Blanc de poulet" },
                    { new Guid("97796814-4f88-40a6-8d3d-98f46135be41"), "Ingredient", "CONDIMENTS", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), true, "Sel" },
                    { new Guid("9e736920-7440-4376-b485-1f192e0d7470"), "Ingredient", "MEAT", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Poulet" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("a456432d-33d1-44d9-be6a-8599bd02becc"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Dentifrice Colgate" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("aac50be3-c2ea-4642-a3d9-81f58299e012"), "Ingredient", "FRUITS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pêche" },
                    { new Guid("ac07af80-640a-4270-9d48-62f8c9b84df6"), "Ingredient", "LEGUMES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Haricots verts" },
                    { new Guid("b09ea0c6-b53a-4a70-bff7-56dcfc5bb2d0"), "Ingredient", "FRUITS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pomme" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), false, "Produit vaiselle" },
                    { new Guid("bdf2a31b-5e8f-4874-838d-3246a804ae13"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Raquette de padel" },
                    { new Guid("be258d12-1679-4aa2-8b71-368b2c16b913"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Fanta" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("c65e7d76-8af8-4e1c-b89e-3102248e73a6"), "Ingredient", "FISH_AND_SEAFOODS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Crevettes" },
                    { new Guid("c762d216-d6ab-43b6-bfe7-cab995c5aea9"), "Ingredient", "MEAT", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Saucisses" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("c7e03ae1-353c-4e21-963f-ff906d09506c"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Coca-Cola" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("cae52516-7547-4d4e-a289-358fd8891a98"), "Ingredient", "CEREALS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pommes de terre" },
                    { new Guid("d35633e3-34cb-48d2-aedc-5a65271357d2"), "Ingredient", "BAKED_AND_PASTRIES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pain" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("d392cdc1-9141-4dc3-ac7e-a4486e2e8774"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pizza surgelée" },
                    { new Guid("d6acb86d-856e-4874-9d64-73a1f3e2f8e9"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Savon liquide Palmolive" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("e5bebf1e-bd35-448c-a1a2-941e55687ff5"), "Ingredient", "MEAT", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Viande de veau" },
                    { new Guid("e6f1fd6a-abb7-4d84-bca8-aeff139dc88c"), "Ingredient", "VEGETABLES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Tomate" },
                    { new Guid("eaa7d8cb-f6ac-40b6-9cfe-6250acb41907"), "Ingredient", "VEGETABLES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Brocoli" },
                    { new Guid("edf88fdd-0117-4aa4-b3a5-17be26c913f9"), "Ingredient", "BEVERAGES", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Lait" }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("f15deb6c-e587-421c-b0cf-1ea1640df7b3"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Déodorant AXE YOU 48H" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("fcf05aed-90e9-47a0-b9b9-09af9bf0f2b9"), "Ingredient", "FATS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Huile d'olive" },
                    { new Guid("ff0cdcf7-aee0-4b9e-b520-8d0fb3b93047"), "Ingredient", "CEREALS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Macaroni" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingList",
                columns: new[] { "Id", "CreatorId", "DoneAt", "IsDone", "IsTemplate", "Name" },
                values: new object[,]
                {
                    { new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, false, true, "Liste de courses habituelle" },
                    { new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), new DateTime(2026, 3, 7, 10, 32, 48, 0, DateTimeKind.Unspecified), true, false, "Liste de courses du samedi 7 mars" },
                    { new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, false, false, "Liste de courses du samedi 28 mars" },
                    { new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, false, false, "Liste de courses de mercredi soir prochain" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListLine",
                columns: new[] { "Id", "Amount", "ArticleId", "Price", "ShoppingListId", "Unit" },
                values: new object[,]
                {
                    { new Guid("0bcd6b9c-0ac1-4b21-b7ac-ec31808d3a8c"), 6.0, new Guid("c7e03ae1-353c-4e21-963f-ff906d09506c"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "LITER" },
                    { new Guid("0f031734-21c3-4978-831d-bdc4f66527ac"), 12.0, new Guid("3d956419-cd5b-41c5-9b2a-d7e5a990c838"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "UNIT" },
                    { new Guid("12e92f83-af4f-4c86-aace-404e9466b69b"), 500.0, new Guid("21d579a9-b2ae-4434-b7d5-45201001bca1"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "GRAM" },
                    { new Guid("1666bda5-7278-4b68-9416-27d0195c1a75"), null, new Guid("4c500d54-1468-4a8c-81f5-ff846fb36b3d"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), null },
                    { new Guid("204138ba-fb1b-4410-b345-8c1ad81ffa47"), 500.0, new Guid("4a5bda61-ac90-4faf-9ae1-139f81a17eb6"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "GRAM" },
                    { new Guid("2144a4da-75da-4dde-b3d9-0ff144a67d31"), null, new Guid("2145139b-64b4-475e-ba84-5efe83d53d8b"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), null },
                    { new Guid("37b52e9a-6b26-4c4b-a4ed-df5c5105d64b"), 4.0, new Guid("e6f1fd6a-abb7-4d84-bca8-aeff139dc88c"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "UNIT" },
                    { new Guid("58ae0ec0-78a1-41a6-bca8-63152e124dbb"), 1.0, new Guid("a456432d-33d1-44d9-be6a-8599bd02becc"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "BOX" },
                    { new Guid("6a475d95-febf-4e24-8f05-5e31452d0d49"), 2.0, new Guid("d392cdc1-9141-4dc3-ac7e-a4486e2e8774"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "BOX" },
                    { new Guid("738afb77-0f6e-44c6-9fb6-9ab850d94b94"), 500.0, new Guid("ac07af80-640a-4270-9d48-62f8c9b84df6"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "GRAM" },
                    { new Guid("76b7acb0-61ac-42fa-9af3-214fb07b7342"), 4.0, new Guid("81bd4a7b-b60c-4e11-8d74-6c641721a928"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "UNIT" },
                    { new Guid("78313e81-5a69-4869-99ce-733fc6023dcb"), 2.0, new Guid("121a810d-3904-4cf1-9af4-063a2e56b62b"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "CAN" },
                    { new Guid("800ca337-3bb0-4108-ab8b-895d392e09c6"), 6.0, new Guid("794f67c2-7afb-495e-8570-6daad6cb4a0a"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "UNIT" },
                    { new Guid("85589ef1-201f-44a1-85ad-3dd3d3b27326"), null, new Guid("924c8c5b-9684-4b77-b5d0-80b0f1cf8b30"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), null },
                    { new Guid("8c0199b7-0569-4ea8-adfc-455113d6a319"), 2.0, new Guid("6ef48e96-a40a-4dc5-9432-fe6d85c87bb6"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "PACK" },
                    { new Guid("9b42859a-1e6b-46cb-8dce-e745c8fdbc4f"), 6.0, new Guid("b09ea0c6-b53a-4a70-bff7-56dcfc5bb2d0"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "UNIT" },
                    { new Guid("9f5d755d-eab1-4c40-8f12-2271ac8413ff"), 600.0, new Guid("9e736920-7440-4376-b485-1f192e0d7470"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "GRAM" },
                    { new Guid("a2fe4f08-aff4-4044-a21d-eaccc7338d72"), 200.0, new Guid("1dd4a5f7-f93f-42ed-919d-c677f0dc0e7f"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "GRAM" },
                    { new Guid("a4930d78-4c79-4207-ad38-d329971ae88d"), 1.0, new Guid("d35633e3-34cb-48d2-aedc-5a65271357d2"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "UNIT" },
                    { new Guid("b7635cb2-3962-472b-94bc-9528f53af09e"), 300.0, new Guid("c65e7d76-8af8-4e1c-b89e-3102248e73a6"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "GRAM" },
                    { new Guid("b9f22fa9-779c-45be-8608-60b429145d0a"), null, new Guid("336ac8ab-c997-4521-a3c1-9aaa5cb86fbb"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), null },
                    { new Guid("bbaaa9a3-591f-46e6-8598-1dcb397add1a"), 500.0, new Guid("ff0cdcf7-aee0-4b9e-b520-8d0fb3b93047"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "GRAM" },
                    { new Guid("be147985-dfa5-417c-815c-822fb15ee073"), 4.0, new Guid("c762d216-d6ab-43b6-bfe7-cab995c5aea9"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "UNIT" },
                    { new Guid("c1f6a7c1-0f40-468b-89c2-e76f50cc5781"), 2.0, new Guid("46703052-e35c-4582-85a8-418f284e0ec8"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "PACK" },
                    { new Guid("ca76e795-7768-48b5-8d32-5fae47084450"), 4.0, new Guid("aac50be3-c2ea-4642-a3d9-81f58299e012"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "UNIT" },
                    { new Guid("dfb86232-fab9-4cff-8b6a-ec25d98171da"), 50.0, new Guid("fcf05aed-90e9-47a0-b9b9-09af9bf0f2b9"), null, new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), "CENTILITER" },
                    { new Guid("e18dc687-be41-475a-be2f-38a31ccfa510"), 1.0, new Guid("d6acb86d-856e-4874-9d64-73a1f3e2f8e9"), null, new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), "PACK" },
                    { new Guid("eb2698fc-8e3e-49f3-b6ee-7f128a0eea45"), 250.0, new Guid("48f07af2-eefb-4097-a479-cc50a3117851"), null, new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), "GRAM" },
                    { new Guid("fee9786c-4d96-44f9-9b2b-5980e9db5802"), 2.0, new Guid("edf88fdd-0117-4aa4-b3a5-17be26c913f9"), null, new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), "LITER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CreatorId",
                table: "Article",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Name_CreatorId",
                table: "Article",
                columns: new[] { "Name", "CreatorId" },
                unique: true,
                filter: "[CreatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CreationToken_AdminCreatorId",
                table: "CreationToken",
                column: "AdminCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_CreatorId",
                table: "ShoppingList",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListLine_ArticleId",
                table: "ShoppingListLine",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListLine_ShoppingListId",
                table: "ShoppingListLine",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreationToken");

            migrationBuilder.DropTable(
                name: "ShoppingListLine");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
