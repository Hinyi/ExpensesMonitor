using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Policies.Gender;

public class MaleGenderPolicy
{
    public bool isApplicable(PolicyData data)
        => data.Gender is Const.Gender.Male;

    public IEnumerable<ProductList> GenerateItems(PolicyData data)
        => new List<ProductList>
        {
            new("Beer", 22, new Price("USD", 12)),
            new("Bener", 12, new Price("USD", 122)),
            new("Bemer", 44, new Price("USD", 1))
        };
}