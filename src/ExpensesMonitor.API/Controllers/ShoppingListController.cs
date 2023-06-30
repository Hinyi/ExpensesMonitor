using ExpensesMonitor.Application.Commands.AddProductsToList;
using ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;
using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Queries.GetShoppingList;
using ExpensesMonitor.Shared.Commands;
using ExpensesMonitor.Shared.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesMonitor.API.Controllers;

public class ShoppingListController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ShoppingListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ShoppingListDto>> Get([FromRoute] GetShoppingList query)
    {
        var result = await _queryDispatcher.QueryAsync<ShoppingListDto>(query);
        return OkOrNotFound(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateShoppingListWithItems command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
    }

    [HttpPut("{shoppingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddProductsToList command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}