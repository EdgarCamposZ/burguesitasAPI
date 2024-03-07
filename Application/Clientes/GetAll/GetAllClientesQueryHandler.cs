using Clientes.Common;
using Domain.Clientes;

namespace Application.Clientes.GetAll;


internal sealed class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, ErrorOr<IReadOnlyList<ClienteResponse>>>
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ClienteResponse>>> Handle(GetAllClientesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Cliente> productos = await _clienteRepository.GetAll();

        return productos.Select(cliente => new ClienteResponse(
                cliente.Id.Value,
                cliente.Nombre,
                cliente.Apellido,
                cliente.Dui,
                cliente.Email,
                cliente.Telefono
            )).ToList();
    }
}