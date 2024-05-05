using ExpensesMonitor.Application.Commands.AddProductsToList;
using ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;
using ExpensesMonitor.Application.Queries.GetAllShoppingLists;
using ExpensesMonitor.Application.Queries.GetShoppingListByName;
using ExpensesMonitor.Application.Queries.GetShoppingListQuery;
using ExpensesMonitor.Application.Queries.SearchShoppingListQuery;
using ExpensesMonitor.Infrastructure.EF.Models;
using ExpensesMonitor.Shared.Commands;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PriceWriteModel = ExpensesMonitor.Application.Commands.AddProductsToList.PriceWriteModel;

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
    
    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<ShoppingListDto>> Get([FromRoute] GetShoppingList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
    
    [HttpGet("/ByName")]
    public async Task<ActionResult<ShoppingListDto>> Get([FromQuery] GetShoppingListByName query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
    
    /// <summary>
    /// Not implemented, instead I used mediatR
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<ShoppingListDto>>> Get([FromQuery] SearchShoppingList query)
    // {
    //     var result = await _queryDispatcher.QueryAsync(query);
    //     return OkOrNotFound(result);
    // }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateShoppingListWithItems command)
    {
        //var result = await _commandDispatcher.DispatchAsync(command);
        //return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/items")]
    public async Task<IActionResult> Put(Guid id,[FromBody] AddNewProductToListReadModel command)
    {
        // command.shoppingListId=shaa AddProductsToList
        var product = new AddProductsToList(id, command.name, command.Quantity,
            new PriceWriteModel(command.price.currency,command.price.amount));
        await _commandDispatcher.DispatchAsync(product);
        return Ok();
    }

    [HttpGet("/All")]
    public async Task<ActionResult<IEnumerable<ShoppingListDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllShoppingLists());

        return Ok(result);
    }
}