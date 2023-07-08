using ExpensesMonitor.Application.Exceptions;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;

namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public class CreateShoppingListWithItemsHandler : ICommandHandler<CreateShoppingListWithItems>
{
    private readonly IShoppingListRepository _repository;
    private readonly IShoppingListFactory _factory;
    private readonly IShoppingListReadService _readService;

    public CreateShoppingListWithItemsHandler(IShoppingListRepository repository
        , IShoppingListFactory factory, IShoppingListReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task HandleAsync(CreateShoppingListWithItems command)
    {
        //var (id, name, occasionWriteModel, gender) = command;
        
        if (await _readService.ExistByNameAsync(command.Name))
        {
            throw new ShoppingListAlreadyExistException(command.Name);
        }

        var occasion = new Occasion(command.Occasion.occasion);

        // var shoppingList = new ShoppingList(new ShoppingListId(new Guid()), command.Name, occasion, command.gender);
        
        var shoppinglist = _factory.CreateWithDefaultItems(new ShoppingListId(new Guid()), command.Name, occasion, command.gender);

        await _repository.AddAsync(shoppinglist);
    }
}