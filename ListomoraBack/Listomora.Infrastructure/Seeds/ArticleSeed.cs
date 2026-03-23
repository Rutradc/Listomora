using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Seeds
{
    public class ArticleSeed : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            #region BaseSeed
            builder.HasData(
                new { Id = SeedIds.Articles.RaquettePadel, Name = "Raquette de padel", IsPublic = false, CreatorId = SeedIds.Users.CristianoRonaldo },
                new { Id = SeedIds.Articles.PapierToilette, Name = "Papier toilette double épaisseur", IsPublic = false, CreatorId = SeedIds.Users.CristianoRonaldo },
                new { Id = SeedIds.Articles.Crayons, Name = "Crayons", IsPublic = true, CreatorId = SeedIds.Users.LionelMessi },
                new { Id = SeedIds.Articles.ProduitVaisselle, Name = "Produit vaiselle", IsPublic = false, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.SacsPoubelle, Name = "Sacs poubelle 30 litres", IsPublic = true, CreatorId = SeedIds.Users.CristianoRonaldo },
                new { Id = SeedIds.Articles.Deodorant, Name = "Déodorant AXE YOU 48H", IsPublic = true, CreatorId = SeedIds.Users.JohnCena }
            );
            #endregion

            #region SeedForShoppingList
            builder.HasData(
                new { Id = SeedIds.Articles.SavonPalmolive, Name = "Savon liquide Palmolive", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.Mouchoirs, Name = "Mouchoirs", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.CocaCola, Name = "Coca-Cola", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.Fanta, Name = "Fanta", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.PizzaSurgelee, Name = "Pizza surgelée", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.ChipsKroky, Name = "Chips Kroky paprika", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.Dentifrice, Name = "Dentifrice Colgate", IsPublic = true, CreatorId = SeedIds.Users.JohnCena },
                new { Id = SeedIds.Articles.PilesAAA, Name = "Piles AAA", IsPublic = true, CreatorId = SeedIds.Users.JohnCena }
            );
            #endregion
        }
    }
}