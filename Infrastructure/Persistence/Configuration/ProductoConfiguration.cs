using Domain.Productos;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            productoId => productoId.Value,
            value => new ProductoId(value));

        builder.Property(c => c.Nombre).HasMaxLength(50);

        builder.Property(c => c.Descripcion).HasMaxLength(250);

        builder.Property(c => c.Precio);

    }
}
