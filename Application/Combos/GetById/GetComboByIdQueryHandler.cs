using Combos.Common;
using Domain.Combos;

namespace Application.Combos.GetById;


internal sealed class GetComboByIdQueryHandler : IRequestHandler<GetComboByIdQuery, ErrorOr<ComboResponse>>
{
    private readonly IComboRepository _comboRepository;

    public GetComboByIdQueryHandler(IComboRepository comboRepository)
    {
        _comboRepository = comboRepository ?? throw new ArgumentNullException(nameof(comboRepository));
    }

    public async Task<ErrorOr<ComboResponse>> Handle(GetComboByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _comboRepository.GetByIdAsync(new ComboId(query.Id)) is not Combo combo)
        {
            return Error.NotFound("Combo.NotFound", "The combo with the provide Id was not found.");
        }

        return new ComboResponse(
            combo.Id.Value, 
            combo.Nombre, 
            combo.Descripcion, 
            combo.Precio,
            combo.ProductoId);
    }
}