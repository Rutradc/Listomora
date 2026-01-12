using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Listomora.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    ArticleType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "IsPublic", "Name" },
                values: new object[] { new Guid("06effa04-6bcf-401f-a091-00b24f6ba8f0"), "Article", true, "Sacs poubelle 30 litres" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("16c4a654-0f04-40eb-a23e-9d580c7062a8"), "Ingredient", "CONDIMENTS", true, "Poivre" },
                    { new Guid("1ed84abe-4c15-458f-82b8-a5a9bc34b5b5"), "Ingredient", "FISH_AND_SEAFOODS", true, "Filet de saumon" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "IsPublic", "Name" },
                values: new object[] { new Guid("34a8bda4-f77f-42e5-ba61-2b511985c4db"), "Article", true, "Crayons" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "IsPublic", "Name" },
                values: new object[] { new Guid("3d11a56b-1b6a-4581-940a-36eb4c25d01c"), "Ingredient", "CEREALS", true, "Spaghetti" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "IsPublic", "Name" },
                values: new object[] { new Guid("6a03f6d7-9160-4d0f-b94b-dbc41d497ec8"), "Article", true, "Papier toilette double épaisseur" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("82a56879-1d59-40f6-8a20-75cdcd2fe686"), "Ingredient", "DAIRY_PRODUCTS", true, "Emmental rapé" },
                    { new Guid("97505262-64f9-4444-83cf-67c93d8161d5"), "Ingredient", "MEAT", true, "Blanc de poulet" },
                    { new Guid("97796814-4f88-40a6-8d3d-98f46135be41"), "Ingredient", "CONDIMENTS", true, "Sel" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"), "Article", true, "Produit vaiselle" },
                    { new Guid("bdf2a31b-5e8f-4874-838d-3246a804ae13"), "Article", true, "Raquette de padel" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "Category", "IsPublic", "Name" },
                values: new object[,]
                {
                    { new Guid("cae52516-7547-4d4e-a289-358fd8891a98"), "Ingredient", "CEREALS", true, "Pommes de terre" },
                    { new Guid("e5bebf1e-bd35-448c-a1a2-941e55687ff5"), "Ingredient", "MEAT", true, "Viande de veau" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleType", "IsPublic", "Name" },
                values: new object[] { new Guid("f15deb6c-e587-421c-b0cf-1ea1640df7b3"), "Article", true, "Déodorant AXE YOU 48H" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
