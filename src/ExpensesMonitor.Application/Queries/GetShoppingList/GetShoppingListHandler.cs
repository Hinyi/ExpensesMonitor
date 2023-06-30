using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingList;

internal sealed class GetShoppingListHandler : IQueryHandler<GetShoppingList, ShoppingListDto>
{
    private readonly IShoppingListReadService _service;

    public GetShoppingListHandler(IShoppingListReadService service)
    {
        _service = service;
    }

    public Task<ShoppingListDto> HandleAsync(GetShoppingList query)
    {
        var result = _service.GetShoppingListById(query);
        return result;
    }
}