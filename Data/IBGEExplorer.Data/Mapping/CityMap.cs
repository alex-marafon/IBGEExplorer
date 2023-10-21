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

        builder.Property(x => x.StateName)
            .HasColumnName("StateName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.CityName)
            .IsRequired()
            .HasColumnName("CityName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.Active)
            .IsRequired()
            .HasColumnName("Active")
            .HasColumnType("BIT")
            .HasDefaultValue(true);
    }
}