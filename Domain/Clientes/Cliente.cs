using Domain.Primitives;

namespace Domain.Clientes;

public sealed class Cliente : AggregateRoot
{
    public Cliente(ClienteId id, string nombre, string apellido, string dui, string email, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Dui = dui;
        Email = email;
        Telefono = telefono;

    }

    private Cliente()
    {

    }

    public ClienteId Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Dui { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
   
    public static Cliente UpdateCliente(Guid id, string nombre, string apellido, string dui, string email, string telefono )
    {
        return new Cliente(new ClienteId(id), nombre, apellido, dui, email, telefono);
    }
}
