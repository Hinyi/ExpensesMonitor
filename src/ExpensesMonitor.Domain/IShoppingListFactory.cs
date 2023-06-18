using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using Gender = ExpensesMonitor.Domain.Const.Gender;

namespace ExpensesMonitor.Domain;

public interface IShoppingListFactory
{
    ShoppingList Create(ShoppingListId id, ShoppingListName name);

    ShoppingList CreateWithDefaultItems(ShoppingListId id, ShoppingListName name, Gender gender);
}