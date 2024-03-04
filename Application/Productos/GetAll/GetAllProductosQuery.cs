using Productos.Common;

namespace Application.Productos.GetAll;

public record GetAllProductosQuery() : IRequest<ErrorOr<IReadOnlyList<ProductoResponse>>>;