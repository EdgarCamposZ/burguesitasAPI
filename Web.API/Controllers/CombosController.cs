using Application.Combos.Create;
using Application.Combos.Update;
using Application.Combos.GetById;
using Application.Combos.Delete;
using Application.Combos.GetAll;

namespace Web.API.Controllers;

[Route("combos")]
public class Combos : ApiController
{
    private readonly ISender _mediator;

    public Combos(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comboResult = await _mediator.Send(new GetAllCombosQuery());

        return comboResult.Match(
            combos => Ok(combos),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var comboResult = await _mediator.Send(new GetComboByIdQuery(id));

        return comboResult.Match(
            combo => Ok(combo),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateComboCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            comboId => Ok(comboId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateComboCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("combo.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            comboId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteComboCommand(id));

        return deleteResult.Match(
            comboId => NoContent(),
            errors => Problem(errors)
        );
    }
}