using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Policies;

public interface IShoppingListPolicy
{
    bool isApplicable(PolicyData data);
    IEnumerable<ProductList> GenerateItems(PolicyData data);
}