namespace Application.Productos.Update;

public record UpdateProductoCommand(
    Guid Id,
    string Nombre,
    string Descripcion,
    double Precio) : IRequest<ErrorOr<Unit>>;