namespace Application.Productos.Create;

public record CreateProductoCommand(
    string Nombre,
    string Descripcion,
    double Precio) : IRequest<ErrorOr<Guid>>;