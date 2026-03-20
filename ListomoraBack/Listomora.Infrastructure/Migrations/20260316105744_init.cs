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
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DateTime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListLine", x => new { x.ArticleId, x.ShoppingListId });
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
<<<<<<<< HEAD:ListomoraBack/Listomora.Infrastructure/Migrations/20260320100734_init.cs
                    { new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), null, "lm10@goat.com", "Lionel", "Messi", "$argon2id$v=19$m=65536,t=3,p=1$xFhzpOjAnFM0WRmYfGqX2Q$nraLcMsTJ1JE/+SqtqbpVgqPf8r/JhGcNpNksHInupA", 1 },
                    { new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, "john@cena.us", "John", "Cena", "$argon2id$v=19$m=65536,t=3,p=1$jtCiYlLrbgpWYGk2n3GE8A$6nvjf01pJU8+SQtS+0kaqNz8O2I8vDKdvWqJPw6RelY", 0 },
                    { new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), null, "cr7@goat.com", "Cristiano", "Ronaldo", "$argon2id$v=19$m=65536,t=3,p=1$p4akL1Q4gdcdkQGfgjIOWQ$RUtq78evmsNxqwF97kf/Wp2WmBbZ5WhbcbnjRRYoWlE", 1 }
========
                    { new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), null, "lm10@goat.com", "Lionel", "Messi", "$argon2id$v=19$m=65536,t=3,p=1$9KglQXiIR6s9qInYYtO/4A$1Xrnsdt/TfiPWtTz1U+R2IfZdXHrdiKO5LlA/8D84hY", 1 },
                    { new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, "john@cena.us", "John", "Cena", "$argon2id$v=19$m=65536,t=3,p=1$OJpq9F8WrMV6gtGQ4YrBVw$aImUMEHxEwpKSrHeBNwBH0oLez53ayOYzehKtlh5zbY", 0 },
                    { new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), null, "cr7@goat.com", "Cristiano", "Ronaldo", "$argon2id$v=19$m=65536,t=3,p=1$NfrlU8e/0Sp1aqqaHkNEzA$IIbZnf2Xj1P6VCPZ8i8cRF/AFzYYXLbQNdjEdN7JAt0", 1 }
>>>>>>>> 7151b33265f52ca51771dad3c0f4e5492c5a1fcc:ListomoraBack/Listomora.Infrastructure/Migrations/20260316105744_init.cs
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
                columns: new[] { "ArticleId", "ShoppingListId", "Amount", "Price", "Unit" },
                values: new object[,]
                {
                    { new Guid("121a810d-3904-4cf1-9af4-063a2e56b62b"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 2.0, null, "CAN" },
                    { new Guid("1dd4a5f7-f93f-42ed-919d-c677f0dc0e7f"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 200.0, null, "GRAM" },
                    { new Guid("2145139b-64b4-475e-ba84-5efe83d53d8b"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), null, null, null },
                    { new Guid("21d579a9-b2ae-4434-b7d5-45201001bca1"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 500.0, null, "GRAM" },
                    { new Guid("336ac8ab-c997-4521-a3c1-9aaa5cb86fbb"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), null, null, null },
                    { new Guid("3d956419-cd5b-41c5-9b2a-d7e5a990c838"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 12.0, null, "UNIT" },
                    { new Guid("46703052-e35c-4582-85a8-418f284e0ec8"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 2.0, null, "PACK" },
                    { new Guid("48f07af2-eefb-4097-a479-cc50a3117851"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 250.0, null, "GRAM" },
                    { new Guid("4a5bda61-ac90-4faf-9ae1-139f81a17eb6"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 500.0, null, "GRAM" },
                    { new Guid("4c500d54-1468-4a8c-81f5-ff846fb36b3d"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), null, null, null },
                    { new Guid("6ef48e96-a40a-4dc5-9432-fe6d85c87bb6"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 2.0, null, "PACK" },
                    { new Guid("794f67c2-7afb-495e-8570-6daad6cb4a0a"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 6.0, null, "UNIT" },
                    { new Guid("81bd4a7b-b60c-4e11-8d74-6c641721a928"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 4.0, null, "UNIT" },
                    { new Guid("924c8c5b-9684-4b77-b5d0-80b0f1cf8b30"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), null, null, null },
                    { new Guid("9e736920-7440-4376-b485-1f192e0d7470"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 600.0, null, "GRAM" },
                    { new Guid("a456432d-33d1-44d9-be6a-8599bd02becc"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 1.0, null, "BOX" },
                    { new Guid("aac50be3-c2ea-4642-a3d9-81f58299e012"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 4.0, null, "UNIT" },
                    { new Guid("ac07af80-640a-4270-9d48-62f8c9b84df6"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 500.0, null, "GRAM" },
                    { new Guid("b09ea0c6-b53a-4a70-bff7-56dcfc5bb2d0"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 6.0, null, "UNIT" },
                    { new Guid("c65e7d76-8af8-4e1c-b89e-3102248e73a6"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 300.0, null, "GRAM" },
                    { new Guid("c762d216-d6ab-43b6-bfe7-cab995c5aea9"), new Guid("5e47b154-be10-43bb-ad15-a09f83d77ff0"), 4.0, null, "UNIT" },
                    { new Guid("c7e03ae1-353c-4e21-963f-ff906d09506c"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 6.0, null, "LITER" },
                    { new Guid("d35633e3-34cb-48d2-aedc-5a65271357d2"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 1.0, null, "UNIT" },
                    { new Guid("d392cdc1-9141-4dc3-ac7e-a4486e2e8774"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 2.0, null, "BOX" },
                    { new Guid("d6acb86d-856e-4874-9d64-73a1f3e2f8e9"), new Guid("49c7a8c0-0647-4380-a588-e8d88c039f06"), 1.0, null, "PACK" },
                    { new Guid("e6f1fd6a-abb7-4d84-bca8-aeff139dc88c"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 4.0, null, "UNIT" },
                    { new Guid("edf88fdd-0117-4aa4-b3a5-17be26c913f9"), new Guid("86a0fcf5-f62e-4809-a28b-a9403514991e"), 2.0, null, "LITER" },
                    { new Guid("fcf05aed-90e9-47a0-b9b9-09af9bf0f2b9"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 50.0, null, "CENTILITER" },
                    { new Guid("ff0cdcf7-aee0-4b9e-b520-8d0fb3b93047"), new Guid("f132fcbf-bcd5-4ce9-ba7b-0dc102fabb72"), 500.0, null, "GRAM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CreatorId",
                table: "Article",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:ListomoraBack/Listomora.Infrastructure/Migrations/20260320100734_init.cs
                name: "IX_Article_Name_CreatorId",
                table: "Article",
                columns: new[] { "Name", "CreatorId" },
                unique: true,
                filter: "[CreatorId] IS NOT NULL");
========
                name: "IX_CreationToken_AdminCreatorId",
                table: "CreationToken",
                column: "AdminCreatorId");
>>>>>>>> 7151b33265f52ca51771dad3c0f4e5492c5a1fcc:ListomoraBack/Listomora.Infrastructure/Migrations/20260316105744_init.cs

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_CreatorId",
                table: "ShoppingList",
                column: "CreatorId");

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
