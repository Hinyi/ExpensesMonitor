using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.SearchShoppingListQuery;

internal sealed class SearchShoppingListHandler : IQueryHandler<SearchShoppingList, IEnumerable<ShoppingListDto>>
{
    public Task<IEnumerable<ShoppingListDto>> HandleAsync(SearchShoppingList query)
    {
        throw new NotImplementedException();
    }
}