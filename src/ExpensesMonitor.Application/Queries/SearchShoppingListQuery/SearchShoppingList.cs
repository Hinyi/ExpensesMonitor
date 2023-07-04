using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.SearchShoppingListQuery;

public record SearchShoppingList : IQuery<IEnumerable<ShoppingListDto>>
{
    public string Name { get; set; }
}