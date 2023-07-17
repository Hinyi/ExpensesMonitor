using ExpensesMonitor.Application.Commands.AddProductsToList;
using ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;
using ExpensesMonitor.Application.Queries.GetShoppingListQuery;
using ExpensesMonitor.Application.Queries.SearchShoppingListQuery;
using ExpensesMonitor.Shared.Commands;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesMonitor.API.Controllers;

public class ShoppingListController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IMediator _mediator;

    public ShoppingListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IMediator mediator)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ShoppingListDto>> Get([FromRoute] GetShoppingList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShoppingListDto>>> Get([FromQuery] SearchShoppingList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateShoppingListWithItems command)
    {
        //var result = await _commandDispatcher.DispatchAsync(command);
        //return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{shoppingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddProductsToList command)
    {
        // command.shoppingListId=shaa
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}