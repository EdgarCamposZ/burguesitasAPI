using Domain.Productos;

namespace Infrastructure.Persistence.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _context;

    public ProductoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Producto producto) => _context.Productos.Add(producto);
    public void Delete(Producto producto) => _context.Productos.Remove(producto);
    public void Update(Producto producto) => _context.Productos.Update(producto);
    public async Task<bool> ExistsAsync(ProductoId id) => await _context.Productos.AnyAsync(producto => producto.Id == id);
    public async Task<Producto?> GetByIdAsync(ProductoId id) => await _context.Productos.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Producto>> GetAll() => await _context.Productos.ToListAsync();
}