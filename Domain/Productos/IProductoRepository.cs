namespace Domain.Productos;

public interface IProductoRepository
{
    Task<List<Producto>> GetAll();
    Task<Producto?> GetByIdAsync(ProductoId id);
    Task<bool> ExistsAsync(ProductoId id);
    void Add(Producto producto);
    void Update(Producto producto);
    void Delete(Producto producto);
}