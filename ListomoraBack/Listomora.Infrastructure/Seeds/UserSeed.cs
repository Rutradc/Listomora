using Isopoh.Cryptography.Argon2;
using Listomora.Domain.Enums;
using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("5bd4bf86-da80-438c-be55-a466ea3b994d"),
                    Email = "john@cena.us",
                    FirstName = "John",
                    LastName = "Cena",
                    Password = Argon2.Hash("laBagarre"), //laBagarre
                    Role = UserRole.ADMIN //TODO : fix pb avec le seed qui lui a donné 1
                }
                );
        }
    }
}
