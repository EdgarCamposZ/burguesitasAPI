namespace Application.Combos.Create;

public record CreateComboCommand(
    string Nombre,
    string Descripcion,
    double Precio) : IRequest<ErrorOr<Guid>>;