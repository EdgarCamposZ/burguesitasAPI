using Productos.Common;
using Domain.Productos;

namespace Application.Productos.GetById;


internal sealed class GetProductoByIdQueryHandler : IRequestHandler<GetProductoByIdQuery, ErrorOr<ProductoResponse>>
{
    private readonly IProductoRepository _productoRepository;

    public GetProductoByIdQueryHandler(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
    }

    public async Task<ErrorOr<ProductoResponse>> Handle(GetProductoByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _productoRepository.GetByIdAsync(new ProductoId(query.Id)) is not Producto producto)
        {
            return Error.NotFound("Producto.NotFound", "The producto with the provide Id was not found.");
        }

        return new ProductoResponse(
            producto.Id.Value, 
            producto.Nombre, 
            producto.Descripcion, 
            producto.Precio);
    }
}