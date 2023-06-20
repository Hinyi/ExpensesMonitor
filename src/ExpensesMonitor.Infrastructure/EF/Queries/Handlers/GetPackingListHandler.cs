using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Queries;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Infrastructure.EF.Models;
using ExpensesMonitor.Shared.Queries;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Queries.Handlers;

internal sealed class GetPackingListHandler : IQueryHandler<GetShoppingList, ShoppingListDto>
{
    private readonly DbSet<ShoppingListReadModel> _shoppingList;

    public GetPackingListHandler(ReadDbContext context)
    {
        _shoppingList = context.ShoppingLists;
    }

    public async Task<ShoppingListDto> HandleAsync(GetShoppingList query)
        => _shoppingList
            .Include(x => x.Items)
            .Where(x => x.Id == query.Id)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .SingleOrDefault();

}