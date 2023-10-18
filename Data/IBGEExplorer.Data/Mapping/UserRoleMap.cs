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
            .HasColumnType("INT");

        builder.HasOne(role => role.User)
            .WithMany(user => user.UserRoles)
            .HasConstraintName("Fk_Users_Roles")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(user => user.Role)
            .WithMany(user => user.UserRoles)
            .HasConstraintName("Fk_Roles_Users")
            .OnDelete(DeleteBehavior.NoAction);
    }
}