using System.Threading.Tasks;
using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.Queries;

namespace ExpensesMonitor.Application.Services;

public interface IShoppingListReadService
{
    Task<bool> ExistByNameAsync(string name);
    Task<ShoppingListDto> GetShoppingListById(GetShoppingList query);
}