using System.Linq.Expressions;
using System.Threading.Tasks;
using ExpensesMonitor.Application.Queries;
using ExpensesMonitor.Application.Queries.GetShoppingListQuery;
using ExpensesMonitor.Application.Queries.SearchShoppingListQuery;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.DTO;

namespace ExpensesMonitor.Application.Services;

public interface IShoppingListReadService
{
    Task<bool> ExistByNameAsync(string name);
    Task<ShoppingListDto?> GetShoppingListById(ShoppingListId id);//Expression<Func<ShoppingList, bool>> query);
    Task<ShoppingListDto?> GetShoppingListByName(ShoppingListName name);
    Task<IEnumerable<ShoppingListDto>> GetShoppingListsByName(SearchShoppingList query);
    Task<IEnumerable<ShoppingListDto>> GetAllAsync();
}