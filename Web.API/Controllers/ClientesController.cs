using Application.Clientes.Create;
using Application.Clientes.Update;
using Application.Clientes.GetById;
using Application.Clientes.Delete;
using Application.Clientes.GetAll;

namespace Web.API.Controllers;

[Route("clientes")]
public class Clientes : ApiController
{
    private readonly ISender _mediator;

    public Clientes(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clienteResult = await _mediator.Send(new GetAllClientesQuery());

        return clienteResult.Match(
            clientes => Ok(clientes),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var clienteResult = await _mediator.Send(new GetClienteByIdQuery(id));

        return clienteResult.Match(
            cliente => Ok(cliente),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClienteCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            clienteId => Ok(clienteId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("cliente.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            clienteId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteClienteCommand(id));

        return deleteResult.Match(
            clienteId => NoContent(),
            errors => Problem(errors)
        );
    }
}