using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.DAL.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new
                {
                    Id = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                    Email = "john@cena.us",
                    FirstName = "John",
                    LastName = "Cena",
                    Password = "AQAAAAIAAYagAAAAENPe+GBHwVUPi9G/MzOxT6Dbsx2WCXHCl+Vc7l//HljQLfj3IPQyNBM0pQAf03H9KA==", //laBagarre
                    Role = "Admin"
                }
                );
        }
    }
}
