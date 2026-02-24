using Isopoh.Cryptography.Argon2;
using Listomora.Domain.Enums;
using Listomora.Domain.Models;
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
                    Password = Argon2.Hash("laBagarre"),
                    Role = UserRole.ADMIN
                },
                new User
                {
                    Id = new Guid("6ad52029-0225-48c4-a2b5-7aa35fec7056"),
                    Email = "cr7@goat.com",
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Password = Argon2.Hash("R1ghtF00t+"),
                    Role = UserRole.USER
                },
                new User
                {
                    Id = new Guid("0eb2993d-7fd5-4f29-9172-1b8f6aa80736"),
                    Email = "lm10@goat.com",
                    FirstName = "Lionel",
                    LastName = "Messi",
                    Password = Argon2.Hash("L3ftF00t+"),
                    Role = UserRole.USER
                }
                );
        }
    }
}
