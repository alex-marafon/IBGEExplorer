using IBGEExplorer.Cities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class CityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("City");
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
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.HasOne(city => city.County)
            .WithOne(county => county.City)
            .HasForeignKey<County>(county => county.IdCity)
            .HasConstraintName("Fk_City_County")
            .OnDelete(DeleteBehavior.NoAction);
    }
}