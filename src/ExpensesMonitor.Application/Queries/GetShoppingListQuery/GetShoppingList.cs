using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingListQuery;

public class GetShoppingList : IQuery<ShoppingListDto>
{
    public Guid Id { get; set; }
} 