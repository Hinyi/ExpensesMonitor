using System.Linq.Expressions;
using ExpensesMonitor.Application.Queries.GetShoppingListQuery;
using ExpensesMonitor.Application.Queries.SearchShoppingListQuery;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Shared.DTO;
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

    public async Task<ShoppingListDto?> GetShoppingListById(ShoppingListId id)//Expression<Func<ShoppingList, bool>> query)
    {
        var result = _shoppingList
            .Set<ShoppingList>()
            .Include(x => x.Items)
            .Where(x => x.Id == id)
            .Select(x => x.AsDto())
            .FirstOrDefault();
        
        return result;
    }

    public async Task<ShoppingListDto?> GetShoppingListByName(ShoppingListName name)
    {
        var result = _shoppingList
            .Set<ShoppingList>()
            .Include(x => x.Items)
            .Where(x => x.Name == name)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .FirstOrDefault();
        // var result = _shoppingList
        //     .Set<ShoppingList>()
        //     .Include(x => x.Items)
        //     .Where(x => x.Name == name)
        //     .Select(x => new ShoppingListDto
        //         {
        //             Name = x.Name,
        //             Id = x.Id,
        //             Items = x.Items.Select(pi => new ProductListDto
        //             {
        //                 Name = pi.Name,
        //                 Quantity = pi.Quantity,
        //                 price = new PriceDto
        //                 {
        //                     amount = pi.Price.Amount,
        //                     currency = pi.Price.Currency
        //                 }
        //             }).ToList()
        //         }
        //     )
        //     .FirstOrDefault();
        
        return result;
    }

    public Task<IEnumerable<ShoppingListDto>> GetShoppingListsByName(SearchShoppingList query)
    {
        // var result = _shoppingList.ShoppingLists.Include(x => x.Items)
        //     .Where(x => x.Name == query.Name)
        //     .Select(x => new E<ShoppingListDto>())
        //     .AsNoTracking();
        //
        // return result;
        return null;
    }

    public async Task<IEnumerable<ShoppingListDto>> GetAllAsync()
    {
        var dbQuery = _shoppingList.Set<ShoppingList>()
            .Include(x => x.Items).AsQueryable();

        Task<List<ShoppingListDto>> result = dbQuery.Select(x => x.AsDto())
            .AsNoTracking()
            .ToListAsync();

        return await result;
    } //=>
    // _shoppingList.ShoppingLists.Include("Items").ToListAsync();
    
}