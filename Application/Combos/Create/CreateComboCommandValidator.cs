namespace Application.Combos.Create;

public class CreateComboCommandValidator : AbstractValidator<CreateComboCommand>
{
    public CreateComboCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Descripcion)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Descripcion");

        RuleFor(r => r.Precio)
            .GreaterThanOrEqualTo(0) // Asegura un valor no negativo
            .LessThanOrEqualTo(9999.99); // Establece un valor máximo (ajustar según sea necesario)

    }
}