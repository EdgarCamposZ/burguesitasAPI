using Clientes.Common;
using Domain.Clientes;

namespace Application.Clientes.GetById;


internal sealed class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, ErrorOr<ClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByIdQueryHandler(IClienteRepository ClienteRepository)
    {
        _clienteRepository = ClienteRepository ?? throw new ArgumentNullException(nameof(ClienteRepository));
    }

    public async Task<ErrorOr<ClienteResponse>> Handle(GetClienteByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _clienteRepository.GetByIdAsync(new ClienteId(query.Id)) is not Cliente cliente)
        {
            return Error.NotFound("Producto.NotFound", "The producto with the provide Id was not found.");
        }

        return new ClienteResponse(
            cliente.Id.Value, 
            cliente.Nombre, 
            cliente.Apellido,
            cliente.Dui,
            cliente.Email, 
            cliente.Telefono);
    }
}