using Productos.Common;
using Domain.Productos;

namespace Application.Productos.GetAll;


internal sealed class GetAllProductosQueryHandler : IRequestHandler<GetAllProductosQuery, ErrorOr<IReadOnlyList<ProductoResponse>>>
{
    private readonly IProductoRepository _productoRepository;

    public GetAllProductosQueryHandler(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ProductoResponse>>> Handle(GetAllProductosQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Producto> productos = await _productoRepository.GetAll();

        return productos.Select(producto => new ProductoResponse(
                producto.Id.Value,
                producto.Nombre,
                producto.Descripcion,
                producto.Precio
            )).ToList();
    }
}