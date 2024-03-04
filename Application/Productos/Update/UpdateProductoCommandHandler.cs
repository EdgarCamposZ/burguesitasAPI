using Domain.Productos;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.Productos.Update;

internal sealed class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, ErrorOr<Unit>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateProductoCommand command, CancellationToken cancellationToken)
    {
        if (!await _productoRepository.ExistsAsync(new ProductoId(command.Id)))
        {
            return Error.NotFound("producto.NotFound", "The producto with the provide Id was not found.");
        }

        Producto producto = Producto.UpdateProducto(command.Id, command.Nombre,
            command.Descripcion,
            command.Precio);

        _productoRepository.Update(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
