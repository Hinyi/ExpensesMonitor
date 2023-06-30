using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Queries;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Services;

internal sealed class ShoppingListReadService : IShoppingListReadService
{
    private readonly ShoppingListDbContext _shoppingList;

    public ShoppingListReadService(ShoppingListDbContext context)
    {
        _shoppingList = context;
    }

    public Task<bool> ExistByNameAsync(string name)
        => _shoppingList.ShoppingLists.AnyAsync(n => n.Name == name);

    public Task<ShoppingListDto> GetShoppingListById(GetShoppingList query)
    {
        throw new NotImplementedException();
    }
}