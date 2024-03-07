using Domain.Clientes;
using Domain.Combos;
using Domain.Productos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Producto> Productos { get; set; }
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Combo> Combos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}