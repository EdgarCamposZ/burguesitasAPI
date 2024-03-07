using Domain.Primitives;

namespace Domain.Combos;

public sealed class Combo : AggregateRoot
{
    public Combo(ComboId id, string nombre, string descripcion, double precio)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        //Productos = new List<Producto>(); // Lista de productos que forman parte del combo
    }

    private Combo() { }

    public ComboId Id { get; private set; }
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }
    public double Precio { get; private set; }
    /*public List<Producto> Productos { get; private set; }

    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }

    public void QuitarProducto(Producto producto)
    {
        Productos.Remove(producto);
    }*/

    public static Combo UpdateCombo(Guid id, string nombre, string descripcion, double precio)
    {
        return new Combo(new ComboId(id), nombre, descripcion, precio);
    }
}
