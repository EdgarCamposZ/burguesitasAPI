using Application.Productos.Create;
using Application.Productos.Update;
using Application.Productos.GetById;
using Application.Productos.Delete;
using Application.Productos.GetAll;

namespace Web.API.Controllers;

[Route("productos")]
public class Productos : ApiController
{
    private readonly ISender _mediator;

    public Productos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productosResult = await _mediator.Send(new GetAllProductosQuery());

        return productosResult.Match(
            productos => Ok(productos),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var productoResult = await _mediator.Send(new GetProductoByIdQuery(id));

        return productoResult.Match(
            producto => Ok(producto),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            productoId => Ok(productoId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductoCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("producto.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            productoId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteProductoCommand(id));

        return deleteResult.Match(
            productoId => NoContent(),
            errors => Problem(errors)
        );
    }
}