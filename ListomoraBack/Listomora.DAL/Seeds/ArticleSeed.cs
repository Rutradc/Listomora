using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.DAL.Seeds
{
    public class ArticleSeed : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(
                new
                {
                    Id = new Guid("bdf2a31b-5e8f-4874-838d-3246a804ae13"),
                    Name = "Raquette de padel"
                },
                new
                {
                    Id = new Guid("6a03f6d7-9160-4d0f-b94b-dbc41d497ec8"),
                    Name = "Papier toilette double épaisseur"
                },
                new
                {
                    Id = new Guid("34a8bda4-f77f-42e5-ba61-2b511985c4db"),
                    Name = "Crayons"
                },
                new
                {
                    Id = new Guid("bb861dfa-889d-49c3-ad76-407d662dd7c2"),
                    Name = "Produit vaiselle"
                },
                new
                {
                    Id = new Guid("06effa04-6bcf-401f-a091-00b24f6ba8f0"),
                    Name = "Sacs poubelle 30 litres"
                },
                new
                {
                    Id = new Guid("f15deb6c-e587-421c-b0cf-1ea1640df7b3"),
                    Name = "Déodorant AXE YOU 48H"
                }
                );
        }
    }
}
