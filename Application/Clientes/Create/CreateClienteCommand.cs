namespace Application.Clientes.Create;

public record CreateClienteCommand(
    string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono) : IRequest<ErrorOr<Guid>>;