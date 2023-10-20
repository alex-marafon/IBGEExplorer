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

        InsertData(builder);
    }

    private void InsertData(EntityTypeBuilder<User> builder)
    {
        var user = new List<User>()
        {
           new User() { Id = 1, CanLogin = true, Email="joao@gmail.com", PasswordHash = "qawsedrf", FullName = "joao da silva" },
           new User() { Id = 2, CanLogin = true, Email="pedro@gmail.com", PasswordHash = "qawsedrf", FullName = "pedro oliveira" }
        };

        user.ForEach(x =>
        {
            builder.HasData(x);
        });
    }
}