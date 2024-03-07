using Combos.Common;
using Domain.Combos;

namespace Application.Combos.GetAll;


internal sealed class GetAllCombosQueryHandler : IRequestHandler<GetAllCombosQuery, ErrorOr<IReadOnlyList<ComboResponse>>>
{
    private readonly IComboRepository _comboRepository;

    public GetAllCombosQueryHandler(IComboRepository comboRepository)
    {
        _comboRepository = comboRepository ?? throw new ArgumentNullException(nameof(comboRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<ComboResponse>>> Handle(GetAllCombosQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Combo> combos = await _comboRepository.GetAll();

        return combos.Select(combo => new ComboResponse(
                combo.Id.Value,
                combo.Nombre,
                combo.Descripcion,
                combo.Precio
            )).ToList();
    }
}