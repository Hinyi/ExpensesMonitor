using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;

namespace ExpensesMonitor.Application.Commands.AddProductsToList;

public class AddProductsToListHandler : ICommandHandler<AddProductsToList>
{
    private readonly IShoppingListRepository _repository;

    public AddProductsToListHandler(IShoppingListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(AddProductsToList command)
    {
        var shoppingList = await _repository.GetAsync(command.shoppingListId);

        if (shoppingList is null)
            throw new Exception();

        var price = new Price(command.price.currency, command.price.amount);
        var shoppingItem = new ProductList(command.name, command.Quantity, price);
        
        shoppingList.AddItem(shoppingItem);

        await _repository.UpdateAsync(shoppingList);
    }
}