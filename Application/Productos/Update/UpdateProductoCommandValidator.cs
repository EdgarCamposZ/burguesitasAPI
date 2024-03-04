namespace Application.Productos.Update;

public class UpdateProductoCommandValidator : AbstractValidator<UpdateProductoCommand>
{
    public UpdateProductoCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Descripcion)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Descripcion");

        RuleFor(r => r.Precio)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(9999.99);
    }
}