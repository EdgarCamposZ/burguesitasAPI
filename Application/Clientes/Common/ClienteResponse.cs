namespace Clientes.Common;

public record ClienteResponse(
Guid Id,
string nombre,
string apellido,
string dui,
string email,
string telefono);