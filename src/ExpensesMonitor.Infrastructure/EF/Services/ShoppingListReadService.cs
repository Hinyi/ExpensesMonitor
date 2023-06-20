using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Services;

internal sealed class ShoppingListReadService : IShoppingListReadService
{
    private readonly DbSet<ShoppingListReadModel> _shoppingList;

    public ShoppingListReadService(ReadDbContext context)
    {
        _shoppingList = context.ShoppingLists;
    }

    public Task<bool> ExistByNameAsync(string name)
        => _shoppingList.AnyAsync(n => n.Name == name);
}