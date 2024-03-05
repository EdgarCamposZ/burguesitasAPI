using Domain.Clientes;
//using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            clienteId => clienteId.Value,
            value => new ClienteId(value));

        builder.Property(c => c.Nombre).HasMaxLength(50);

        builder.Property(c => c.Apellido).HasMaxLength(50);

         builder.Property(c => c.Dui).HasMaxLength(10);

          builder.Property(c => c.Email).HasMaxLength(50);

           builder.Property(c => c.Telefono).HasMaxLength(9);

       

    }
}
