using IBGEExplorer.Account.Entities;
using IBGEExplorer.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.HashSalt)
            .IsRequired()
            .HasColumnName("Hash")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.CanLogin)
            .IsRequired()
            .HasColumnName("CanLogin")
            .HasColumnType("BIT")
            .HasDefaultValue(false);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("LastName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(70);

        InsertData(builder);
    }

    private void InsertData(EntityTypeBuilder<User> builder)
    {
        var user = new List<User>()
        {
           new User() { Id = 1, CanLogin = true, Email="joao@gmail.com", Password = "qawsedrf", FirstName = "joao", LastName = "Silva" },
           new User() { Id = 2, CanLogin = true, Email="pedro@gmail.com", Password = "qawsedrf", FirstName = "pedro", LastName = "oliveira" }
        };

        user.ForEach(x =>
        {
            x.SetHashSalt(StringExtensions.CreateSalt());
            x.Password = StringExtensions.GenerateSha256Hash(x.HashSalt!, x.Password);
            builder.HasData(x);
        });
    }
}