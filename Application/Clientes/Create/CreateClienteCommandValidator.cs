namespace Application.Clientes.Create;

public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Apellido)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Apellido");

            RuleFor(r => r.Dui)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Dui");

            RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Email");

            RuleFor(r => r.Telefono)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Telefono");

       

    }
}