namespace Application.Productos.Delete;

public record DeleteProductoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;