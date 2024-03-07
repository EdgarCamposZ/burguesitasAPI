using Combos.Common;

namespace Application.Combos.GetAll;

public record GetAllCombosQuery() : IRequest<ErrorOr<IReadOnlyList<ComboResponse>>>;