using Listomora.Domain.Enums;
using Listomora.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Listomora.Infrastructure.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.FirstName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(a => a.LastName)
                .HasMaxLength(150);
            builder
                .Property(u => u.Password)
                .HasColumnName("Password")
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(a => a.Email)
                .HasMaxLength(320)
                .IsRequired();
            builder
                .Property(u => u.Role)
                .HasDefaultValue(UserRole.USER)
                .IsRequired();
            builder
                .Property(u => u.DisableDate)
                .HasColumnType("DateTime2");

            string rolesString = "";
            var roles = Enum.GetValues<UserRole>();
            foreach (UserRole role in roles)
            {
                rolesString += (int)role + ",";
            }
            rolesString = rolesString[..^1];

            //constraints
            builder.HasKey(a => a.Id)
                .HasName("PK_User");
            builder.HasIndex(a => a.Email)
                .IsUnique();
            builder.ToTable(t => t.HasCheckConstraint(
                    "CK_User_Role",
                    "[Role] IN (" + rolesString + ")"
                ));
        }
    }
}
