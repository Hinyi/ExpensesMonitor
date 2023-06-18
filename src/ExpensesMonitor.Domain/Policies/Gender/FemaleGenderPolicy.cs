using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Policies.Gender;

public class FemaleGenderPolicy : IShoppingListPolicy
{
    public bool isApplicable(PolicyData data)
        => data.Gender is Const.Gender.Female;

    public IEnumerable<ProductList> GenerateItems(PolicyData data)
        => new List<ProductList>
        {
            new("Lipstick", 12, new Price("USD", 12)),
            new("Lipstick", 12, new Price("USD", 122)),
            new("Lipstick", 12, new Price("USD", 1))
        };
}