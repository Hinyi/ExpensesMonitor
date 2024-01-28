using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries.GetShoppingListByName;

public class GetShoppingListByName : IQuery<ShoppingListDto>
{
    public string Name { get; set; }
}