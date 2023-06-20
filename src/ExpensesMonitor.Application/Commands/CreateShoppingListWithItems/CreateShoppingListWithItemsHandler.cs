using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;

namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public class CreateShoppingListWithItemsHandler : ICommandHandler<CreateShoppingListWithItems>
{
    private readonly IShoppingListRepository _repository;
    private readonly IShoppingListFactory _factory;
    private readonly IShoppingListReadService _readService;

    public CreateShoppingListWithItemsHandler(IShoppingListRepository repository, IShoppingListFactory factory, IShoppingListReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task HandleAsync(CreateShoppingListWithItems command)
    {
        var (id, name, occasion, gender) = command;

        if (await _readService.ExistByNameAsync(name))
        {
            throw new Exception();
        }

        var shoppinglist = _factory.CreateWithDefaultItems(id, name, occasion, gender);

        await _repository.AddAsync(shoppinglist);
    }
}