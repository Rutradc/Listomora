using Listomora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Listomora.Infrastructure.Configuration
{
    public class CreationTokenConfig : IEntityTypeConfiguration<CreationToken>
    {
        public void Configure(EntityTypeBuilder<CreationToken> builder)
        {
            builder.ToTable("CreationToken");

            builder.Property(c => c.TokenHash)
                .HasMaxLength(64)
                .HasColumnType("char(64)")
                .IsRequired();

            builder.Property(c => c.ExpiresAt)
                .IsRequired();

            builder.Property(c => c.UsedAt);

            //constraints
            builder.HasKey(c => c.TokenHash).HasName("PK_CreationToken");

            //relations
            // creationToken <> user
            builder.HasOne(c => c.AdminCreator)
                .WithMany(d => d.CreationTokens)
                .HasForeignKey(c => c.AdminCreatorId)
                .HasConstraintName("FK_CreationToken_AdminCreator");
        }
    }
}
