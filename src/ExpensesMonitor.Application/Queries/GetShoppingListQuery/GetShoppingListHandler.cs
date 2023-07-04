using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingListQuery;

internal sealed class GetShoppingListHandler : IQueryHandler<GetShoppingList, ShoppingListDto>
{
    private readonly IShoppingListReadService _service;

    public GetShoppingListHandler(IShoppingListReadService service)
    {
        _service = service;
    }

    public async Task<ShoppingListDto> HandleAsync(GetShoppingList query)
    {
        var id = new ShoppingListId(query.Id);
        var result = await _service.GetShoppingListById(id);//x => x.Id == id);

        return result;
    }
}