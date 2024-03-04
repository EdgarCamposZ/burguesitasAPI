using Domain.Productos;
using Domain.Primitives;
//using Domain.ValueObjects;
//using Domain.DomainErrors;

namespace Application.Productos.Create;

public sealed class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ErrorOr<Guid>>
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
    {
        _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateProductoCommand command, CancellationToken cancellationToken)
    {

        var producto = new Producto(
            new ProductoId(Guid.NewGuid()),
            command.Nombre,
            command.Descripcion,
            command.Precio
        );

        _productoRepository.Add(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return producto.Id.Value;
    }
}
