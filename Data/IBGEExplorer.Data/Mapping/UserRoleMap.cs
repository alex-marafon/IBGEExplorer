using IBGEExplorer.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class UserRoleMap : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("UserId")
            .HasColumnType("INT");

        builder.Property(x => x.RoleId)
            .IsRequired()
            .HasColumnName("RoleId")
            .HasColumnType("smallint");

        builder.HasOne(role => role.User)
            .WithMany(user => user.UserRoles)
            .HasConstraintName("Fk_Users_Roles")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(user => user.Role)
            .WithMany(user => user.UserRoles)
            .HasConstraintName("Fk_Roles_Users")
            .OnDelete(DeleteBehavior.NoAction);

        InsertData(builder);
    }

    private void InsertData(EntityTypeBuilder<UserRole> builder)
    {
        var role = new List<UserRole>()
        {
           new UserRole(){ Id = 1, UserId = 1, RoleId = 1 },
           new UserRole(){ Id = 2, UserId = 2, RoleId = 2 },
        };

        role.ForEach(x =>
        {
            builder.HasData(x);
        });
    }
}