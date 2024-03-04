using Domain.Productos;
using Domain.Primitives;

namespace Application.Productos.Delete;

internal sealed class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, ErrorOr<Unit>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteProductoCommand command, CancellationToken cancellationToken)
    {
        if (await _productoRepository.GetByIdAsync(new ProductoId(command.Id)) is not Producto producto)
        {
            return Error.NotFound("producto.NotFound", "The producto with the provide Id was not found.");
        }

        _productoRepository.Delete(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
