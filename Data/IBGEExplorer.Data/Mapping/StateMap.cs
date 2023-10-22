using IBGEExplorer.Cities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGEExplorer.Data.Mapping;

public class StateMap : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("Code")
            .HasMaxLength(15);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.Acronym)
            .HasColumnName("Acronym")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(2);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
    }
}