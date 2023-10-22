using IBGEExplorer.Cities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class IBGEMap : IEntityTypeConfiguration<IBGE>
{
    public void Configure(EntityTypeBuilder<IBGE> builder)
    {
        builder.ToTable("IBGE");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.IBGECode)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("IBGECode")
            .HasMaxLength(20);

        builder.HasIndex(x => x.IBGECode)
            .IsUnique();

        builder.Property(x => x.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder.Property(x => x.IdCounty)
            .IsRequired()
            .HasColumnName("IdCounty")
            .HasColumnType("INT");

        builder.HasOne(city => city.County)
            .WithOne(county => county.City)
            .HasForeignKey<IBGE>(city => city.IdCounty)
            .OnDelete(DeleteBehavior.NoAction);
    }
}