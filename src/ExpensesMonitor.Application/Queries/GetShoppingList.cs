using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries;

public class GetShoppingList : IQuery<ProductListDto>, IQuery<ShoppingListDto>
{
    public Guid Id { get; set; }
}