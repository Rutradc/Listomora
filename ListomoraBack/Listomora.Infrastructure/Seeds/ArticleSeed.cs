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
                new
                {
                    Id = new Guid("bdf2a31b-5e8f-4874-838d-3246a804ae13"),
                    Name = "Raquette de padel",
                    IsPublic = false,
                    CreatorId = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                },
                new
                {
                    Id = new Guid("6a03f6d7-9160-4d0f-b94b-dbc41d497ec8"),
                    Name = "Papier toilette double épaisseur",
                    IsPublic = false,
                    CreatorId = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                },
                new
                {
                    Id = new Guid("34a8bda4-f77f-42e5-ba61-2b511985c4db"),
                    Name = "Crayons",
                    IsPublic = true,
                    CreatorId = new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"),
                },
                new
                {
                    Id = new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"),
                    Name = "Produit vaiselle",
                    IsPublic = false,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("06effa04-6bcf-401f-a091-00b24f6ba8f0"),
                    Name = "Sacs poubelle 30 litres",
                    IsPublic = true,
                    CreatorId = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                },
                new
                {
                    Id = new Guid("f15deb6c-e587-421c-b0cf-1ea1640df7b3"),
                    Name = "Déodorant AXE YOU 48H",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
            );
            #endregion
            #region SeedForShoppingList
            builder.HasData(
                new
                {
                    Id = new Guid("d6acb86d-856e-4874-9d64-73a1f3e2f8e9"),
                    Name = "Savon liquide Palmolive",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("6ef48e96-a40a-4dc5-9432-fe6d85c87bb6"),
                    Name = "Mouchoirs",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("c7e03ae1-353c-4e21-963f-ff906d09506c"),
                    Name = "Coca-Cola",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("be258d12-1679-4aa2-8b71-368b2c16b913"),
                    Name = "Fanta",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("d392cdc1-9141-4dc3-ac7e-a4486e2e8774"),
                    Name = "Pizza surgelée",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("336ac8ab-c997-4521-a3c1-9aaa5cb86fbb"),
                    Name = "Chips Kroky paprika",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("a456432d-33d1-44d9-be6a-8599bd02becc"),
                    Name = "Dentifrice Colgate",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                },
                new
                {
                    Id = new Guid("81bd4a7b-b60c-4e11-8d74-6c641721a928"),
                    Name = "Piles AAA",
                    IsPublic = true,
                    CreatorId = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                }
            );
            #endregion
        }
    }
}
