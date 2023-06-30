using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingListQuery;

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