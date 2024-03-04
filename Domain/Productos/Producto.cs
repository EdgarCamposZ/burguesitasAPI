using Domain.Primitives;

namespace Domain.Productos;

public sealed class Producto : AggregateRoot
{
    public Producto(ProductoId id, string nombre, string descripcion, double precio)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
    }

    private Producto()
    {

    }

    public ProductoId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public double Precio { get; set; }

    public static Producto UpdateProducto(Guid id, string nombre, string descripcion, double precio)
    {
        return new Producto(new ProductoId(id), nombre, descripcion, precio);
    }
}