using IBGEExplorer.Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);

        InsertData(builder);
    }

    private void InsertData(EntityTypeBuilder<Role> builder) 
    {
        var role = new List<Role>()
        {
           new Role(){ Id = 1, Name = "Admin" },
           new Role(){ Id = 2, Name = "User" }
        };

        role.ForEach(x =>
        {
            builder.HasData(x);
        });
    }
}