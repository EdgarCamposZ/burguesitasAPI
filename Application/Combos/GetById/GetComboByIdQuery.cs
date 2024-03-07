using Combos.Common;

namespace Application.Combos.GetById;

public record GetComboByIdQuery(Guid Id) : IRequest<ErrorOr<ComboResponse>>;