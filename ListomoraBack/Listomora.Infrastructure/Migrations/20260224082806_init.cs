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
                name: "Users",
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
                name: "Articles",
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
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisableDate", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), null, "lm10@goat.com", "Lionel", "Messi", "$argon2id$v=19$m=65536,t=3,p=1$ZDeYfEWWpk1m7MQx6SOMng$ItM+S+c4GDbdGloYuieW6DAYDIO4y4HdDoWsnv6Wl6w", 1 },
                    { new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), null, "john@cena.us", "John", "Cena", "$argon2id$v=19$m=65536,t=3,p=1$6GXdGoruD5Mbs390Ww5kqw$4hHZ0JEnuZS8TznnDop+UpoJI1mPZE6o13SKMDkLaP8", 0 },
                    { new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), null, "cr7@goat.com", "Cristiano", "Ronaldo", "$argon2id$v=19$m=65536,t=3,p=1$o1qPwuNhroI6TTdSXWUnGA$FpvVj7q+p6240Ckq4WH7GY6XIpo/1LeadQ07Gm4jqMc", 1 }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("06effa04-6bcf-401f-a091-00b24f6ba8f0"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), true, "Sacs poubelle 30 litres" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("16c4a654-0f04-40eb-a23e-9d580c7062a8"), "Ingredient", "CONDIMENTS", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), false, "Poivre" },
                    { new Guid("1ed84abe-4c15-458f-82b8-a5a9bc34b5b5"), "Ingredient", "FISH_AND_SEAFOODS", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), true, "Filet de saumon" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("34a8bda4-f77f-42e5-ba61-2b511985c4db"), "Article", new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"), true, "Crayons" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("3d11a56b-1b6a-4581-940a-36eb4c25d01c"), "Ingredient", "CEREALS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Spaghetti" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("6a03f6d7-9160-4d0f-b94b-dbc41d497ec8"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Papier toilette double épaisseur" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("82a56879-1d59-40f6-8a20-75cdcd2fe686"), "Ingredient", "DAIRY_PRODUCTS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Emmental rapé" },
                    { new Guid("97505262-64f9-4444-83cf-67c93d8161d5"), "Ingredient", "MEAT", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), false, "Blanc de poulet" },
                    { new Guid("97796814-4f88-40a6-8d3d-98f46135be41"), "Ingredient", "CONDIMENTS", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), true, "Sel" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), false, "Produit vaiselle" },
                    { new Guid("bdf2a31b-5e8f-4874-838d-3246a804ae13"), "Article", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Raquette de padel" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "CreatorId", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("cae52516-7547-4d4e-a289-358fd8891a98"), "Ingredient", "CEREALS", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Pommes de terre" },
                    { new Guid("e5bebf1e-bd35-448c-a1a2-941e55687ff5"), "Ingredient", "MEAT", new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"), false, "Viande de veau" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "CreatorId", "IsPublic", "Name" },
                values: new object[] { new Guid("f15deb6c-e587-421c-b0cf-1ea1640df7b3"), "Article", new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"), true, "Déodorant AXE YOU 48H" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatorId",
                table: "Articles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
