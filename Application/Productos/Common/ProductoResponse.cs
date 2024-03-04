namespace Productos.Common;

public record ProductoResponse(
Guid Id,
string nombre,
string descripcion,
double precio);