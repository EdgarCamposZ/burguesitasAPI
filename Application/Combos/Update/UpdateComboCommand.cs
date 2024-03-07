namespace Application.Combos.Update;

public record UpdateComboCommand(
    Guid Id,
    string Nombre,
    string Descripcion,
    double Precio) : IRequest<ErrorOr<Unit>>;