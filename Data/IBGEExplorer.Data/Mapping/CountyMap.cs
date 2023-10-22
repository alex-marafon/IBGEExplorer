using IBGEExplorer.Cities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class CountyMap : IEntityTypeConfiguration<County>
{
    public void Configure(EntityTypeBuilder<County> builder)
    {
        builder.ToTable("County");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("Code")
            .HasMaxLength(15);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.IdState)
            .IsRequired()
            .HasColumnName("IdState")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.HasOne(county => county.State)
            .WithMany(state => state.Counties)
            .HasConstraintName("Fk_County_State")
            .OnDelete(DeleteBehavior.NoAction);
    }
}