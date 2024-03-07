namespace Application.Clientes.Update;

public record UpdateClienteCommand(
    Guid Id,
    string Nombre,
    string Apellido,
    string Dui,
    string Email,
    string Telefono) : IRequest<ErrorOr<Unit>>;