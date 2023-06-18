using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain;

public interface IShoppingListRepository
{
    Task<ShoppingList> GetAsync(ShoppingListId id);
    Task AddAsync(ProductList productList);
    Task UpdateAsync(ProductList productList);
    Task DeleteAsync(ProductList productList);
}