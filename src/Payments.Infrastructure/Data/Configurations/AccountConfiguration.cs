using Payments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Infrastructure.Identity;

namespace Payments.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.OwnerId).IsRequired().HasMaxLength(450);
        builder.Property(a => a.Balance).HasPrecision(18, 2);

        builder.HasIndex(a => a.OwnerId);

        builder.HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(table => table.HasCheckConstraint(
            "CK_Accounts_Balance_NonNegative", "\"Balance\" >= 0"));
    }
}