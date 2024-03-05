using Domain.Clientes;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.Clientes.Update;

internal sealed class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, ErrorOr<Unit>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
    {
        if (!await _clienteRepository.ExistsAsync(new ClienteId(command.Id)))
        {
            return Error.NotFound("cliente.NotFound", "The cliente with the provide Id was not found.");
        }

        Cliente cliente = Cliente.UpdateCliente(command.Id, command.Nombre,
            command.Apellido,
            command.Dui,
            command.Email,
            command.Telefono);

        _clienteRepository.Update(cliente);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

