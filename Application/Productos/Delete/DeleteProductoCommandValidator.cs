namespace Application.Productos.Delete;

public class DeleteProductoCommandValidator : AbstractValidator<DeleteProductoCommand>
{
    public DeleteProductoCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}