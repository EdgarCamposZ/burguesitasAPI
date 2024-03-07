using Domain.Combos;
using Domain.Primitives;

namespace Application.Combos.Delete;

internal sealed class DeleteComboCommandHandler : IRequestHandler<DeleteComboCommand, ErrorOr<Unit>>
{
    private readonly IComboRepository _comboRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteComboCommandHandler(IComboRepository comboRepository, IUnitOfWork unitOfWork)
    {
        _comboRepository = comboRepository ?? throw new ArgumentNullException(nameof(comboRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(DeleteComboCommand command, CancellationToken cancellationToken)
    {
        if (await _comboRepository.GetByIdAsync(new ComboId(command.Id)) is not Combo combo)
        {
            return Error.NotFound("Combo.NotFound", "The combo with the provide Id was not found.");
        }

        _comboRepository.Delete(combo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
