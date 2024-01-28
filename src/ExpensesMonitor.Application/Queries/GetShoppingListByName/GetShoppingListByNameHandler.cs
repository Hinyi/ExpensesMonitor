using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingListByName;

internal sealed class GetShoppingListByNameHandler : IQueryHandler<GetShoppingListByName, ShoppingListDto>
{
    private readonly IShoppingListReadService _service;

    public GetShoppingListByNameHandler(IShoppingListReadService service)
    {
        _service = service;
    }

    public async Task<ShoppingListDto> HandleAsync(GetShoppingListByName query)
    {
        var name = new ShoppingListName(query.Name);
        var result = await _service.GetShoppingListByName(name);

        return result;
    }
}