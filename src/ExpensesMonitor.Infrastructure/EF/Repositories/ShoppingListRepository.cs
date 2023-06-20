using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Repositories;

internal sealed class ShoppingListRepository : IShoppingListRepository
{
    private readonly DbSet<ShoppingList> _shoppingLists;
    private readonly WriteDbContext _writeDbContext;

    public ShoppingListRepository(WriteDbContext writeDbContext)
    {
        _shoppingLists = writeDbContext.ShoppingLists;
        _writeDbContext = writeDbContext;
    }

    public async Task<ShoppingList> GetAsync(ShoppingListId id)
        =>  _shoppingLists.Include("_items").SingleOrDefault(x => x.Id == id);

    public async Task AddAsync(ShoppingList shoppingList)
    {
        await _shoppingLists.AddAsync(shoppingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ShoppingList shoppingList)
    {
        _shoppingLists.Update(shoppingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ShoppingList shoppingList)
    {
        _shoppingLists.Remove(shoppingList);
        await _writeDbContext.SaveChangesAsync();
    }
}