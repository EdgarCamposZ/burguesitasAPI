using Domain.Clientes;
using Domain.Primitives;

namespace Application.Clientes.Delete;

internal sealed class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, ErrorOr<Unit>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteClienteCommand command, CancellationToken cancellationToken)
    {
        if (await _clienteRepository.GetByIdAsync(new ClienteId(command.Id)) is not Cliente producto)
        {
            return Error.NotFound("producto.NotFound", "The producto with the provide Id was not found.");
        }

        _clienteRepository.Delete(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
