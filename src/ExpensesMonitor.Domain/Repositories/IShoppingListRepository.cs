using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Repositories;

public interface IShoppingListRepository
{
    Task<ShoppingList> GetAsync(ShoppingListId id);
    Task AddAsync(ShoppingList shoppingList);
    Task UpdateAsync(ShoppingList shoppingList);
    Task DeleteAsync(ShoppingList shoppingList);
}