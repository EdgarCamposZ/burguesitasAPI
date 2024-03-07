namespace Application.Combos.Delete;

public record DeleteComboCommand(Guid Id) : IRequest<ErrorOr<Unit>>;