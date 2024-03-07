using Domain.Combos;
using Domain.Primitives;
//using Domain.ValueObjects;

namespace Application.Combos.Update;

internal sealed class UpdateComboCommandHandler : IRequestHandler<UpdateComboCommand, ErrorOr<Unit>>
{
    private readonly IComboRepository _comboRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateComboCommandHandler(IComboRepository comboRepository, IUnitOfWork unitOfWork)
    {
        _comboRepository = comboRepository ?? throw new ArgumentNullException(nameof(comboRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateComboCommand command, CancellationToken cancellationToken)
    {
        if (!await _comboRepository.ExistsAsync(new ComboId(command.Id)))
        {
            return Error.NotFound("Combo.NotFound", "The combo with the provide Id was not found.");
        }

        Combo combo = Combo.UpdateCombo(command.Id, command.Nombre,
            command.Descripcion,
            command.Precio);

        _comboRepository.Update(combo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
