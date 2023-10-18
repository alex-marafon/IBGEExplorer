using IBGEExplorer.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.PasswordHash)
            .HasColumnName("PasswordHash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.CanLogin)
            .IsRequired()
            .HasColumnName("CanLogin")
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasColumnName("FullName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
    }
}