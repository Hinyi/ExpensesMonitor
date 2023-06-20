using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Shared.Queries;

namespace ExpensesMonitor.Application.Queries;

public class SearchShoppingList : IQuery<IEnumerable<ProductListDto>>
{
    public string SearchPhrase { get; set; }
}