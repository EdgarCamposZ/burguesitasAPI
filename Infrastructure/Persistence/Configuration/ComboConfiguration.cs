using Domain.Combos;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ComboConfiguration : IEntityTypeConfiguration<Combo>
{
    public void Configure(EntityTypeBuilder<Combo> builder)
    {
        builder.ToTable("Combos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            comboId => comboId.Value,
            value => new ComboId(value));

        builder.Property(c => c.Nombre).HasMaxLength(50);

        builder.Property(c => c.Descripcion).HasMaxLength(250);

        builder.Property(c => c.Precio);

        builder.Property(c => c.ProductoId);

    }
}
