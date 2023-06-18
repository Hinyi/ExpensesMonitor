using ExpensesMonitor.Domain.Entities;

namespace ExpensesMonitor.Domain.Policies;

public interface IShoppingListPolicy
{
    bool isApplicable(PolicyData data);
    IEnumerable<Product> GenerateItems(PolicyData data);
}