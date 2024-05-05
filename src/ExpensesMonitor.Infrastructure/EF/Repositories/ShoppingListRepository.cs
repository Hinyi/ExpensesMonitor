using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Repositories;

internal sealed class ShoppingListRepository : IShoppingListRepository
{
    private readonly ShoppingListDbContext _shoppingLists;

    public ShoppingListRepository(ShoppingListDbContext ShoppingLists)
    {
        _shoppingLists = ShoppingLists;

    }

    public async Task<ShoppingList> GetAsync(ShoppingListId id)
        =>  _shoppingLists.ShoppingLists.Include("Items").SingleOrDefault(x => x.Id == id);

    public async Task AddAsync(ShoppingList shoppingList)
    {
        await _shoppingLists.AddAsync(shoppingList);
        await _shoppingLists.SaveChangesAsync();
    }

    public async Task UpdateAsync(ShoppingList shoppingList)
    {
        _shoppingLists.Update(shoppingList);
        await _shoppingLists.SaveChangesAsync();
    }

    public async Task DeleteAsync(ShoppingList shoppingList)
    {
        _shoppingLists.Remove(shoppingList);
        await _shoppingLists.SaveChangesAsync();
    }


}