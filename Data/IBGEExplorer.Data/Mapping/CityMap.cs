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
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.IBGECode)
            .IsRequired()
            .HasColumnName("IBGECode")
            .HasColumnType("INT")
            .HasMaxLength(10);

        builder.Property(x => x.CityName)
            .IsRequired()
            .HasColumnName("CityName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);


        builder.Property(x => x.UFSigla)
            .IsRequired()
            .HasColumnName("UF")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(5);


        builder.Property(x => x.UFName)
            .IsRequired()
            .HasColumnName("UFName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(75);

    }
}