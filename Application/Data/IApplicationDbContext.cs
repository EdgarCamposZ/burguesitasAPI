using Domain.Clientes;
using Domain.Productos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Producto> Productos { get; set; }
    DbSet<Cliente> Clientes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}