namespace Application.Combos.Delete;

public class DeleteComboCommandValidator : AbstractValidator<DeleteComboCommand>
{
    public DeleteComboCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}