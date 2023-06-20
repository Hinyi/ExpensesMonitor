using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Policies;
using ExpensesMonitor.Domain.ValueObjects;
using Gender = ExpensesMonitor.Domain.Const.Gender;

namespace ExpensesMonitor.Domain;

public class ShoppingListFactory : IShoppingListFactory
{
    private readonly IEnumerable<IShoppingListPolicy> _policies;

    public ShoppingListFactory(IEnumerable<IShoppingListPolicy> policies)
    {
        _policies = policies;
    }

    public ShoppingList Create(ShoppingListId id, ShoppingListName name)
        => new(id, name);

    public ShoppingList CreateWithDefaultItems(ShoppingListId id, ShoppingListName name, Occasion occasion,
        Gender gender)
    {
        var data = new PolicyData(occasion, gender);
        var applicablePolicies = _policies.Where(x => x.isApplicable(data));

        var items = applicablePolicies.SelectMany(x => x.GenerateItems(data));
        var shoppingList = Create(id, name);
        
        shoppingList.AddItems(items);

        return shoppingList;
    }
}