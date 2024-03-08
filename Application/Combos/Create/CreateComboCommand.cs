namespace Application.Combos.Create;

public record CreateComboCommand(
    string Nombre,
    string Descripcion,
    double Precio,
    string ProductoId) : IRequest<ErrorOr<Guid>>;