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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16c4a654-0f04-40eb-a23e-9d580c7062a8"), "Poivre" },
                    { new Guid("1ed84abe-4c15-458f-82b8-a5a9bc34b5b5"), "Filet de saumon" },
                    { new Guid("3d11a56b-1b6a-4581-940a-36eb4c25d01c"), "Spaghetti" },
                    { new Guid("82a56879-1d59-40f6-8a20-75cdcd2fe686"), "Emmental rapé" },
                    { new Guid("97505262-64f9-4444-83cf-67c93d8161d5"), "Blanc de poulet" },
                    { new Guid("97796814-4f88-40a6-8d3d-98f46135be41"), "Sel" },
                    { new Guid("cae52516-7547-4d4e-a289-358fd8891a98"), "Pommes de terre" },
                    { new Guid("e5bebf1e-bd35-448c-a1a2-941e55687ff5"), "Viande de veau" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
