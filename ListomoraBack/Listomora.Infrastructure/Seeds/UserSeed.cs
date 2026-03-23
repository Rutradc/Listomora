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
                    Id = SeedIds.Users.JohnCena,
                    Email = "john@cena.us",
                    FirstName = "John",
                    LastName = "Cena",
                    Password = Argon2.Hash("laBagarre"),
                    Role = UserRole.ADMIN
                },
                new User
                {
                    Id = SeedIds.Users.CristianoRonaldo,
                    Email = "cr7@goat.com",
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Password = Argon2.Hash("R1ghtF00t+"),
                    Role = UserRole.USER
                },
                new User
                {
                    Id = SeedIds.Users.LionelMessi,
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