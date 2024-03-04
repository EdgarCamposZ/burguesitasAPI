using Productos.Common;

namespace Application.Productos.GetById;

public record GetProductoByIdQuery(Guid Id) : IRequest<ErrorOr<ProductoResponse>>;