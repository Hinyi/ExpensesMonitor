using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries;

public class GetShoppingList : IQuery<ProductListDto>
{
    public Guid Id { get; set; }
}