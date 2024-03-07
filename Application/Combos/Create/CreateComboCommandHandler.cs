using Domain.Combos;
using Domain.Primitives;
//using Domain.ValueObjects;
//using Domain.DomainErrors;

namespace Application.Combos.Create;

public sealed class CreateComboCommandHandler : IRequestHandler<CreateComboCommand, ErrorOr<Guid>>
{
    private readonly IComboRepository _comboRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateComboCommandHandler(IComboRepository comboRepository, IUnitOfWork unitOfWork)
    {
        _comboRepository = comboRepository ?? throw new ArgumentNullException(nameof(comboRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Guid>> Handle(CreateComboCommand command, CancellationToken cancellationToken)
    {

        var combo = new Combo(
            new ComboId(Guid.NewGuid()),
            command.Nombre,
            command.Descripcion,
            command.Precio
        );

        _comboRepository.Add(combo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return combo.Id.Value;
    }
}
